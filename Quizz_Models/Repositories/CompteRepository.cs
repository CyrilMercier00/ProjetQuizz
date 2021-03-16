using Quizz_Models.bdd_quizz;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Quizz_Models.DTO;

namespace Quizz_Models.Repositories
{
     public class CompteRepository
     {
          private readonly bdd_quizzContext bdd_entities;
          public CompteRepository(bdd_quizzContext quizzContext)
          {
               bdd_entities = quizzContext;
          }

          /// <summary>
          /// Méthode qui retourne tout les comptes de la bdd.
          /// </summary>
          /// <returns>Liste de tout les comptes.</returns>
          public List<Compte> GetAllComptes()
          {
               return bdd_entities.Compte.Include(c => c.FkPermissionNavigation).ToList();
          }

          /// <summary>
          /// Méthode qui trouve un compte par email.
          /// </summary>
          /// <param name="mail"></param>
          /// <returns>Retourne l'entité compte correspondante.</returns>
          public Compte FindCompteByMail(string mail)
          {
               Compte c = null;
               try
               {
                    c = bdd_entities.Compte.Where(c => c.Mail == mail).First();
               }
               catch (Exception)
               { }

               return c;
          }

          /// <summary>
          /// Obtenir les comptes d'une certaines permissions.
          /// </summary>
          /// <param name="prmidPerm">ID de la permission</param>
          /// <returns>Les comptes ayant prmidPerm comme id de permission.</returns>
          public List<Compte> GetCompteByNomPerm(int prmidPerm)
          {
               return bdd_entities.Compte
                   .Where(x => x.FkPermission == prmidPerm)
                   .ToList();

          }

          internal Compte GetCompteRecruteurByCodeQuizz(string prmCode)
          {
               Quizz quizz = bdd_entities.Quizz
                   .Include(x => x.CompteQuizz)
                   .Where(x => x.Urlcode == prmCode)
                   .SingleOrDefault();

               CompteQuizz comptequizz = bdd_entities.CompteQuizz
                   .Where(x => x.FkQuizz == quizz.PkQuizz)
                   .SingleOrDefault();

               return bdd_entities.Compte
                   .Where(x => x.PkCompte == comptequizz.FkCompte)
                   .Single();
          }

          public Compte GetCompteRecruteurByIdQuizz(int prmIdQuizz)
          {

               Compte c = null;
               try
               {
                    c = bdd_entities.Compte.Join(bdd_entities.CompteQuizz,
                              c => c.PkCompte,
                              cQ => cQ.FkCompte,
                              (c, cQ) => new { compte = c, compte_Q = cQ })
                     .Where(ccQ => ccQ.compte_Q.FkQuizz == prmIdQuizz & ccQ.compte_Q.EstCreateur == 1)
                     .Select(ccQ => ccQ.compte)
                     .Single();
               }
               catch (Exception)
               {
               }

               return c;
          }

          /// <summary>
          /// Retourne les comptes ayant comme referent le compte avec l'id passé.
          /// </summary>
          /// <param name="iDPerm"></param>
          /// <returns></returns>
          internal List<Compte> GetCompteByCompteRef(int prmID = 1)
          {
               return bdd_entities.Compte
                   .Where(x => x.FkCompteReferent == prmID)
                   .ToList();
          }

          /// <summary>
          /// Méthode qui retourne un compte par son ID.
          /// </summary>
          /// <param name="prmID">ID du compte.</param>
          /// <returns>Le compte demandé.</returns>
          public Compte GetCompteByID(int prmID)
          {
               Compte c = null;
               try
               {
                    c = bdd_entities.Compte.Where(c => c.PkCompte == prmID).Include(c => c.FkPermissionNavigation).Single();
               }
               catch (Exception)
               { }

               return c;
          }

          /// <summary>
          /// Méthode qui ajoute un compte dans la bdd.
          /// </summary>
          /// <param name="prmCompte">Entité du compte.</param>
          public void InsertCompte(Compte prmCompte)
          {
               bdd_entities.Compte.Add(prmCompte);
          }

          /// <summary>
          /// Méthode qui modifie la permission d'un utilisateur.
          /// </summary>
          /// <param name="idCompte">ID du compte à modifier.</param>
          /// <param name="idPermission">ID de la permission voulue.</param>
          public void ModifyPermission(int idCompte, int idPermission)
          {
               Compte c = bdd_entities.Compte.Find(idCompte);
               if (c != null)
               {
                    c.FkPermission = idPermission;
               }
               bdd_entities.SaveChanges();
          }

          /// <summary>
          /// Méthode qui prépare la bdd à une modification de compte.
          /// </summary>
          /// <param name="compte">Entité du compte à modifier.</param>
          public void ModifyCompte(Compte compte)
          {
               bdd_entities.Entry(compte).State = EntityState.Modified;
          }

          /// <summary>
          /// Méthode qui supprime un compte via l'ID du compte.
          /// </summary>
          /// <param name="CompteID">ID du compte.</param>
          public void DeleteCompte(int CompteID)
          {
               Compte CompteEntity = bdd_entities.Compte.Find(CompteID);
               bdd_entities.Compte.Remove(CompteEntity);
          }

          /// <summary>
          /// Sauvegarde les éléments du contexte dans la base de donnée.
          /// </summary>
          /// <returns>Nombre de lignes ajoutées dans la bdd.</returns>
          public int Sauvegarder()
          {
               int lignes;
               try
               {
                    lignes = bdd_entities.SaveChanges();
               }
               catch (Microsoft.EntityFrameworkCore.DbUpdateException)
               {
                    lignes = -1;
               }
               return lignes;
          }
     }
}

import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../url_api';
import { Quizz } from "../DTO/quizzDTO"
import { JsonpClientBackend } from '@angular/common/http';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})
export class GenQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  idCompte = this.getCompteID();    // ID du compte utilisateur
  inputNbQuestion = 0;              // Nombre de questions affiché dans l'input
  inputTheme = "c#";                //
  inputComplexite = "Débutant";     //
  quizz = new Quizz();              // Le DTO du quizz qui va etre envoyé a l'api
  valRetourRequeteTheme;            // Contiens le retour de la requete theme
  valRetourRequeteComplex;          // Contiens le retour de la requete complexite




  /* ------ Constructeur ------ */
  constructor() { }

  ngOnInit()
  {
    this.setValeursAFfichage();
  }

  /* --- Insertion des valeurs dans les balises select --- */
  setValeursAFfichage()
  {
    try
    {
      this.valRetourRequeteTheme = this.getAllTheme();
      this.valRetourRequeteComplex = this.getAllComplexite();

      if (this.valRetourRequeteTheme != null)
      {
        {
          if (this.valRetourRequeteComplex != null)
          {
            // Pour chaque niveau dans le data de la requete
            for (var niveau in this.valRetourRequeteComplex)
            {
              // Creation & configuration d'une balise html
              var element = document.createElement("option");                         // Element vide
              element.setAttribute("value", this.valRetourRequeteComplex[ niveau ]);  // Ajouter attribut
              document.getElementById("").appendChild(element);                       // Ajouter a la liste
            }
          } else
          {
            throw new Error('Probleme lors de la récuperation du niveau de complextité')
          }
        }
      } else
      {
        throw new Error('Probleme de de la récuperation des themes ')
      }
    } catch (e)
    {
      alert("Debug: " + e.message)
    }
  }



  // Retourne l'id du compte qui a créer le quizz
  getCompteID()
  {
    return 1;
  }




  /* ------ Fonctions acces api ------ */
  /* --- Envoie du DTO local a l'api pour insertion du quizz ---*/
  CreerQuizz()
  {
    console.log("Creer quizz");
  }



  /* --- Retourne le json des themes disponibles--- */
  getAllTheme()
  {
    let reponse = fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        return json;
      });
  }



  /* -- Retourne le json des complexites disponibles --- */
  getAllComplexite()
  {
    let reponse = fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        return JSON.parse(json);
      });
  }

}

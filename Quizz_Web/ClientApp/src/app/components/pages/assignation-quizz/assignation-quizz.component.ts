/*
------------------------------------------------------------
    TODO : Recup de l'id du compte & l'envoyer avec le quizz
------------------------------------------------------------
*/
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VariableGlobales } from '../../../url_api';
import { Router } from "@angular/router";
import { DTOQuizz } from '../../../DTO/dto-quizz';



@Component({
  selector: 'app-assignation-quizz',
  templateUrl: './assignation-quizz.component.html',
  styleUrls: ['./assignation-quizz.component.css', '../../../app.flex-util.css']
})



export class AssignationQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */

  resultatForm: FormGroup;               // Contiens les valeurs du formulaire d'assignation de quizz
  dataQuizz: any;                        // Contiens le quizz passé de la page generation de quizz
  concatForms: any;                      // Contiens les valeur des deux formulaires pour l'envoi a l'api



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder, private router: Router)
  {
    this.dataQuizz = this.router.getCurrentNavigation().extras.state;
    this.resultatForm = this.builder.group
      ({
        compte: ['', Validators.required]
      })
  }



  /* --- Methodes Angular --- */
  ngOnInit() { }



  /* ------ Fonctions ------ */
  /* --- Insertion du quizz & gestion erreur --- */
  onSubmit()
  {
    try
    {
      let quizzGen: DTOQuizz = new DTOQuizz;

      quizzGen.nbQuestions = this.dataQuizz.nbQuestions;
      quizzGen.theme = this.dataQuizz.theme;
      quizzGen.complexite = this.dataQuizz.complexites;
      this.getCompteCandidatID().then(valID => { quizzGen.idCompteCandidat = valID });
      quizzGen.idCompteRecruteur = this.getCompteRecruteurID();

      this.insertQuizz(quizzGen);
    } catch (e)
    {
      console.log(e);
    }
  }



  /* ---  Retourne l'id du compte qui a créer le quizz --- */
  getCompteRecruteurID()
  { /* ---------- TODO ---------- */
    return 1;
  }



  /* --- Refacto, id stocké en local ? --- */
  /* --- Requete GET a l'api pour le candidat avec ce nom --- */
  async getCompteCandidatID()
  {
    const reponse = await fetch(VariableGlobales.apiURLCompte + "/0/Candidat", { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        return JSON.parse(JSON.stringify(json.mail));
      });
    return reponse
  }



  /* ------ Fonctions acces api ------ */
  /* --- Envoie a l'api pour insertion du quizz ---*/
  insertQuizz(data: DTOQuizz)
  {
    fetch(
      VariableGlobales.apiURLQuizz,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      }
    )
  }

}

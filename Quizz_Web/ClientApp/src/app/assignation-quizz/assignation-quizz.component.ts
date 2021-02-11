import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VariableGlobales } from '../url_api';
import { Router } from "@angular/router";


@Component({
  selector: 'app-assignation-quizz',
  templateUrl: './assignation-quizz.component.html',
  styleUrls: [ './assignation-quizz.component.css', '../app.flex-util.css' ]
})



export class AssignationQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteCompteAssigne: any;    // Contiens le retour de la requete get all compte assigne au recruteur
  resultatForm: FormGroup;               // Contiens les valeurs du formulaire d'assignation de quizz
  dataQuizz: any;                        // Contiens le quizz passé de la page generation de quizz
  concatForms: any;                      // Contiens les valeur des deux formulaires pour l'envoi a l'api



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder, private router: Router)
  {
    this.dataQuizz = this.router.getCurrentNavigation().extras.state;
    console.log(this.dataQuizz);
    this.resultatForm = this.builder.group
      ({
        compte: [ '', Validators.required ]
      })
  }



  /* --- Methodes Angular --- */
  ngOnInit() { }

  onSubmit()
  {
    //this.concatForms = this.resultatForm + this.inputQuizz;
    console.log(this.concatForms);
    this.creerQuizz(this.concatForms);
  }



  /* ------ Fonctions ------ */
  /* --- Insertion du quizz & gestion erreur --- */
  creerQuizz(prmDataQuizz: string)
  {
    try
    {
      this.insertQuizz(prmDataQuizz);
    } catch (e)
    {
      console.log(e);
    }
  }



  /* ------ Fonctions acces api ------ */
  /* --- Envoie a l'api pour insertion du quizz ---*/
  async insertQuizz(data: string)
  {
    console.log("InsertQuizz: " + data);
    let reponse = await fetch(
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
    reponse;
  }



  async getCandidatAsigne()
  {
    fetch(VariableGlobales.apiURLCompte, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteCompteAssigne = JSON.parse(JSON.stringify(json));
      });
  }


}

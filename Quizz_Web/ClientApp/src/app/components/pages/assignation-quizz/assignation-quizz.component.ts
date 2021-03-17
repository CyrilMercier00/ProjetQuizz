import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from "@angular/router";
import { VariableGlobales } from '../../../url_api';
import { Globals } from 'src/app/globals';
import { CreationQuizzDTO } from 'src/app/DTO/CreationQuizzDTO';


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
  idCandidat: number;



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder, private router: Router)
  {
    this.dataQuizz = this.router.getCurrentNavigation().extras.state;
    this.resultatForm = this.builder.group
      ({
        compte: [0, Validators.required]
      });
    this.idCandidat = 0;
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {

  }



  /* ------ Fonctions ------ */
  /* --- Insertion du quizz & gestion erreur --- */
  onSubmit()
  {
    let quizzGen: CreationQuizzDTO = new CreationQuizzDTO;

    let nbQuestion : number = parseInt(this.dataQuizz.form.nbQuestions);
    let FKCompteCandidat: number = parseInt(this.idCandidat.toString());
    let FKCompteRecruteur: number = parseInt(this.getCompteRecruteurID().toString());
    quizzGen.$FKCompteCandidat = FKCompteCandidat;
    quizzGen.$NbQuestions = nbQuestion;
    quizzGen.$Theme = this.dataQuizz.form.theme;
    quizzGen.$Complexite = this.dataQuizz.form.complexite;
    quizzGen.$FKCompteRecruteur = FKCompteRecruteur;

    this.insertQuizz(quizzGen);
  }




  setValeurFormIDCandidat(prmID: number)
  {
    this.idCandidat = prmID;
  }



  /* ---  Retourne l'id du compte qui a créer le quizz --- */
  getCompteRecruteurID(): number
  { 
    let jwt = Globals.decodeJwt();
    return jwt['id'];
  }



  /* ------ Fonctions acces api ------ */
  /* --- Envoie a l'api pour insertion du quizz ---*/
  async insertQuizz(data: CreationQuizzDTO)
  {

    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    await fetch(
      VariableGlobales.apiURLQuizz,
      {
        method: "POST",
        headers: requestHeaders,
        body: JSON.stringify(data)
      }
    ).then(lambda => this.returnHome());
  }

  returnHome(): void{
    this.router.navigateByUrl('login');
  }
}

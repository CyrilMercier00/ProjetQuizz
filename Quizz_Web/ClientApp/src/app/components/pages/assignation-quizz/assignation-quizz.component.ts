/*
------------------------------------------------------------
    TODO : Recup de l'id du compte & l'envoyer avec le quizz
------------------------------------------------------------
*/

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { DTOQuizz } from '../../../DTO/dto-quizz';
import { Router } from "@angular/router";
import { ServiceQuizz } from 'src/app/Service/serviceQuizz';


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
  ngOnInit()
  {

  }



  /* ------ Fonctions ------ */
  /* --- Insertion du quizz & gestion erreur --- */
  onSubmit()
  {
    console.log(this.dataQuizz);
    let quizzGen: DTOQuizz = new DTOQuizz;

    quizzGen.$NbQuestions = this.dataQuizz.form.nbQuestions;
    quizzGen.$Theme = this.dataQuizz.form.theme;
    quizzGen.$Complexite = this.dataQuizz.form.complexite;
    quizzGen.$FKCompteRecruteur = this.getCompteRecruteurID();

    this.insertQuizz(quizzGen);
    console.log(quizzGen);
    // this.router.navigate(['/'])
  }




  setValeurFormIDCandidat(prmID: number)
  {
    this.resultatForm.patchValue({ "compte": prmID })
    console.log(this.resultatForm.value)
  }



  /* ---  Retourne l'id du compte qui a créer le quizz --- */
  getCompteRecruteurID(): number
  { /* ---------- TODO ---------- */
    return 1;
  }



  /* ------ Fonctions acces api ------ */
  /* --- Envoie a l'api pour insertion du quizz ---*/
  insertQuizz(data: DTOQuizz)
  {
    ServiceQuizz.InsertQuizz(data)
  }

}

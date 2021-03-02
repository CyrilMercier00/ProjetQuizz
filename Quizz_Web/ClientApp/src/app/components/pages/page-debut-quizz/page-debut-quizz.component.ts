import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { ServiceQuestions } from 'src/app/Services/serviceQuestion'
import { ServiceQuizz } from 'src/app/Services/serviceQuizz'

@Component({
  selector: 'app-page-debut-quizz',
  templateUrl: './page-debut-quizz.component.html',
  styleUrls: ['./page-debut-quizz.component.css', '../../../app.flex-util.css']
})



export class PageDebutQuizzComponent implements OnInit
{
  /* --- Variables --- */
  code: string;
  quizz: any;



  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute)
  {
    this.code = this.actRoute.snapshot.params['urlQuizz'];
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {


    ServiceQuizz.GetQuizzByCode(this.code)               // Aller chercher le quizz avec le code passé
      .then(repFetch =>
      {
        repFetch.json()                                  // Extraire les données json de la promise
          .then(retour => { this.quizz = retour })       // Sauvegarder les données
          .then(x =>
          {
            ServiceQuestions.GetQuestionsByCodeQuizz(this.quizz.urlcode)    // Chercher les questions associées a ce quizz
              .then(repFetch =>
              {
                repFetch.json()                          // Extraire les données json de la promise
                  .then(retour =>                        // Sauvegarder les données en array
                  {
                    this.questionToArray(retour);
                  }
                  )
              })
          });
      })

  }


  /*--- Methodes ---*/
  handleClick()
  {
    console.log(this.quizz);
  }



  questionToArray(prmData: any)
  {
    console.log(prmData);
  }









}

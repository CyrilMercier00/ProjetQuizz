import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';
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
  dataQuizz: DTOQuizz;
  dataQuestions: DTOQuestion[];


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
          .then(retour => { this.dataQuizz = retour })   // Sauvegarder les données
          .then(x =>
          {
            ServiceQuestions.GetQuestionsByCodeQuizz(this.dataQuizz.$UrlCode)    // Chercher les questions associées a ce quizz
              .then(repFetch =>
              {
                repFetch.json()                          // Extraire les données json de la promise
                  .then(retour =>                        // Sauvegarder les données en array
                  {
                    this.dataQuestions = retour;
                    this.startQuizz();
                  }
                  )
              })
          });
      })

  }


  /*--- Methodes ---*/
  handleClick()
  {
    console.log(this.dataQuizz);
  }



  questionToArray(prmData: any)
  {
    console.log(prmData);
  }



  startQuizz()
  {
console.log("cc")
    this.dataQuestions.forEach(question =>
    {
      console.log(question);
    })

  }








}

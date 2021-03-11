import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';
import { ServiceQuestions } from 'src/app/Services/serviceQuestion'
import { ServiceQuizz } from 'src/app/Services/serviceQuizz'
import { utilDTO } from 'src/app/DTO/utilDTO';

@Component({
  selector: 'app-page-debut-quizz',
  templateUrl: './page-debut-quizz.component.html',
  styleUrls: ['./page-debut-quizz.component.css', '../../../app.flex-util.css']
})



export class PageDebutQuizzComponent implements OnInit
{
  /* --- Variables --- */
  code: string;                           // Contiens le code url de la page
  dataQuizz: DTOQuizz;                    // Contiens le quizz correspondant au code de la page
  arrayDataQuestions: DTOQuestion[];      // Contiens toutes les questions récupérées pour ce quizz
  dataQuestion: DTOQuestion;              // Contiens les données de la question actuellement posée
  componentRepQCMEnabled: boolean         // Active ou désactive le component de réponse aux questions QCM
  componentRepLibreEnabled: boolean       // Active ou désactive le component formulaire de réponse au questions libres
  isReady: boolean                        // Active le bouton commencer si la recuperaion des données a bien été faite



  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute)
  {
    this.code = this.actRoute.snapshot.params['urlQuizz'];
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {

    // * Récuperation des données du quizz
    ServiceQuizz.GetQuizzByCode(this.code)               // Aller chercher le quizz avec le code passé
      .then(repFetch =>
      {
        repFetch.json()                                  // Extraire les données json de la promesse
          .then(retour => { this.dataQuizz = utilDTO.DTOTransformQuizz(retour) })   // Sauvegarder les données
          .then(x =>
          {
            ServiceQuestions.GetQuestionsByCodeQuizz(this.dataQuizz.$UrlCode)       // Chercher les questions associées a ce quizz
              .then(repFetch =>
              {
                repFetch.json()                          // Extraire les données json de la promesse
                  .then(retour =>                        // Sauvegarder les données dans un array
                  {
                    console.log(retour)
                    this.arrayDataQuestions = utilDTO.DTOTransformQuestion(retour);
                    console.log(this.arrayDataQuestions)
                    this.isReady = true;
                  }
                  )
              })
          });
      })

  }



  /*--- Methodes ---*/
  handleClick()
  {
    this.startQuizz();
  }



  /* --- Activer les component correspondant aux types de questions posée  ---  */
  startQuizz()
  {
    this.arrayDataQuestions.forEach(question =>
    {
      // * Preparation des données pour la prochaine question
      this.dataQuestion = question;

      if (question.$RepLibre == true)
      {
        // * Desactiver le component inutile et activer celui correspondant à la question
        this.componentRepQCMEnabled = false;
        this.componentRepLibreEnabled = true;

      } else
      {
        this.componentRepLibreEnabled = false;
        this.componentRepQCMEnabled = true;
      }

    })
  }

}

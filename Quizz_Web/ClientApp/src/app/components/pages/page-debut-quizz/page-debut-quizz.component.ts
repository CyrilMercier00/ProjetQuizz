import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';

import { ChronoComponent } from '../../chrono/chrono.component';
import { ComptePersonnelDTO } from 'src/app/DTO/ComptePersonnelDTO';
import { CompteService } from 'src/app/Service/CompteService'
import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';
import { Globals } from 'src/app/globals';
import { PermissionService } from 'src/app/Service/permissionService';
import { ServiceQuestions } from 'src/app/Service/serviceQuestion'
import { ServiceQuizz } from 'src/app/Service/serviceQuizz';
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
  componentChronoEnabled: boolean         // Active ou désactive le component chrono
  isReady: boolean                        // Active le bouton commencer si la recuperation des données a bien été faite
  showWelcome = true                      // Cache l'ecran de debut de quizz si false
  nbQuestionRepondues = 0                 // Contiens l'index de la question actuelle
  idCompte: number                       // ID du compte qui passe le quizz

  /***chrono**/
  TimeQ;



  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute)
  {
    this.code = this.actRoute.snapshot.params['urlQuizz'];
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    CompteService.GetCompteLinkedToCode(this.code)
      .then(repFetch =>
      {
        repFetch.json()
          .then(retour =>
          {
            console.log(retour)
            let compte = new ComptePersonnelDTO(retour.nom, retour.prenom, null)
            compte.$PkCompte = retour.PkCompte
          }).then(() =>
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
                            this.isReady = true;
                          }
                          )
                      })
                  });
              })
          )
      })
  }



  /*--- Methodes ---*/
  handleClick()
  {
    this.startQuizz();
  }



  /*redirige vers la page quizz success*/
  redirectNotFind()
  {
    let jwt = Globals.decodeJwt();
    this.router.navigate(['/quizzsuccess/' + this.code + '/' + jwt['id']]);
  }



  /* --- Activer les component correspondant aux types de questions posée  ---  */
  startQuizz()
  {
    this.showWelcome = false
    this.componentChronoEnabled = false
    this.nextQuestion()
  }



  // Passe à la prochaine question
  nextQuestion()
  {
    this.dataQuestion = this.arrayDataQuestions[this.nbQuestionRepondues]

    // * Afficher le component correct pour cette question
    if (this.dataQuestion.$RepLibre)
    {
      this.componentRepQCMEnabled = false
      this.componentRepLibreEnabled = true
      this.componentChronoEnabled = true

    } else
    {
      this.componentRepLibreEnabled = false
      this.componentRepQCMEnabled = true
      this.componentChronoEnabled = true
    }
    // STop chrono
  }


  EnregisteChrono()
  {
    ChronoComponent;
  }

  // Incremente le nombre de questions repondues et trigger l'affichage de la prochaine question
  incrementNBQuestionRep()
  {
    if (this.nbQuestionRepondues + 1 == this.arrayDataQuestions.length)
    {
      this.redirectNotFind();

    } else
    {
      this.nbQuestionRepondues++
      this.nextQuestion()
    }

  }

}

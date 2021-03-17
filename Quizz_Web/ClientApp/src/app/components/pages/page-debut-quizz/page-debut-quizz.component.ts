import { ActivatedRoute, Router } from '@angular/router';
import { Component, Input, OnInit, ViewChild } from '@angular/core';

import { AuthService } from 'src/app/Service/AuthService';
import { ChronoComponent } from '../../chrono/chrono.component';
import { ComptePersonnelDTO } from 'src/app/DTO/ComptePersonnelDTO';
import { CompteService } from 'src/app/Service/CompteService'
import { ConnexionDTO } from 'src/app/DTO/ConnexionDTO';
import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';
import { Globals } from 'src/app/globals';
import { PageReponseLibreComponent } from '../page-reponse-libre/page-reponse-libre.component';
import { PageReponseQcmComponent } from '../page-reponse-qcm/page-reponse-qcm.component';
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
  /* --- Declaration des variables --- */
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
  idCompte: number                        // ID du compte qui passe le quizz
  @ViewChild(PageReponseLibreComponent, { static: false }) childRefLibre: PageReponseLibreComponent;
  @ViewChild(PageReponseQcmComponent, { static: false }) childRefQCM: PageReponseQcmComponent;
  @ViewChild(ChronoComponent, { static: false }) childRefChrono: ChronoComponent;


  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute, private authService: AuthService)
  {
    this.code = this.actRoute.snapshot.params['urlQuizz'];
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    if (Globals.isLoggedOut())
    {
      Globals.initJwt('');
    }

    // ! Enregistrer le compte du candidat qui passe
    CompteService.GetCompteLinkedToCode(this.code)
      .then(repFetch =>
      {

        repFetch.json().then(retour =>
        {

          let compte = new ComptePersonnelDTO(retour.nom, retour.prenom, null)
          compte.$PkCompte = retour.pk
          compte.$Mail = retour.mail

          this.authService.connectCandidat(new ConnexionDTO(compte.$Mail, null))
            .subscribe(
              jwt =>
              {
                Globals.initJwt(jwt);
              }
            )
        }).then(() =>

          // ! Récuperation des données du quizz
          ServiceQuizz.GetQuizzByCode(this.code)

            .then(repFetch =>
            {
              repFetch.json().then(retour =>
              {
                this.dataQuizz = utilDTO.DTOTransformQuizz(retour)
              })
                .then(x =>
                {
                  // ! Récuperation des questions du quizz
                  ServiceQuestions.GetQuestionsByCodeQuizz(this.dataQuizz.$UrlCode)
                    .then(repFetch =>
                    {
                      repFetch.json().then(retour =>
                      {
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
  redirect()
  {
    let jwt = Globals.decodeJwt();
    this.router.navigate(['/quizzsuccess/' + this.code + '/' + jwt['id']]);
  }



  /* --- Activer les component correspondant aux types de questions posée  ---  */
  startQuizz()
  {
    this.showWelcome = false              // Cacher l'ecran d'accueil
    this.componentChronoEnabled = true    // Demarrer le chrono
    this.nextQuestion()                   // Demarrer l'affichage de questions
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

    } else
    {
      this.componentRepLibreEnabled = false
      this.componentRepQCMEnabled = true
    }

  }



  // Incremente le nombre de questions repondues et trigger l'affichage de la prochaine question
  incrementNBQuestionRep()
  {

    if (this.childRefLibre) { this.childRefLibre.setVal() }
    else if (this.childRefChrono) { this.childRefQCM.setVal() }

    console.log(this.nbQuestionRepondues)

    if (this.nbQuestionRepondues + 1 >= this.arrayDataQuestions.length)
    {

      console.log("redirect")

      this.componentChronoEnabled = false;
      this.redirect();

    } else
    {

      console.log("pas redirect")
      this.nbQuestionRepondues++
      this.nextQuestion()

    }

  }

}

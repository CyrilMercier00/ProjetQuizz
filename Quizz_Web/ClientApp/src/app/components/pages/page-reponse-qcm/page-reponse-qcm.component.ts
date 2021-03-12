import { Component, Input, OnInit, Output } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { Router } from '@angular/router';
import { VariableGlobales } from 'src/app/url_api';
import { reponseDTO } from '../../../DTO/reponseDTO';
import { utils } from 'src/app/utils';

@Component({
  selector: 'app-page-reponse-qcm',
  templateUrl: './page-reponse-qcm.component.html',
  styleUrls: ['./page-reponse-qcm.component.css', '../../../app.flex-util.css']
})



export class PageReponseQcmComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  @Input("dataQuestion") dataQ: any;    // DTO de la question passée
  rep1: string;               // Texte de la réponse 1
  rep2: string;               // Texte de la réponse 2
  rep3: string;               // Texte de la réponse 3
  rep4: string;               // Texte de la réponse 4
  enonce: string;             // Enonce de la question
  textCommentaire: string;    // Commentaire du candidat



  /* ------ Constructeur ------ */
  constructor(private router: Router)
  {
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
    console.log("called")
    console.log(this.dataQ)
    this.enonce == this.dataQ.$Enonce;

    // * Choisis les reponses aléatoirement
    // Génère un array de 4 nombre entre 0 et le nombre max de reponses disponibles pour cette question
    let arrayNbChoisis = utils.nbAleatUnique(4, 0, this.dataQ.$ListeReponses.length)

    // Utiliser ces nombres pour afficher le questions
    this.rep1 == this.dataQ.$ListeReponses[arrayNbChoisis[0]];
    this.rep2 == this.dataQ.$ListeReponses[arrayNbChoisis[1]];
    this.rep3 == this.dataQ.$ListeReponses[arrayNbChoisis[2]];
    this.rep4 == this.dataQ.$ListeReponses[arrayNbChoisis[3]];
  }



  /* ------ Methodes ------*/
  // Envoi de la réponse a la base de données
  handleBtnClick(event)
  {
    let data = new reponseDTO();

    data.$Commentaire = this.textCommentaire;
    data.$Reponse = event.target.value;
    data.$FKCompte = 0;
    data.$FKQuestion = parseInt(this.router.getCurrentNavigation().extras.state["fkQuestion"]);

    this.envoiFormulaire(data);
  }



  /* --- POST de la reponse choisie --- */
  envoiFormulaire(prmDTO: reponseDTO)
  {
    fetch(
      VariableGlobales.apiURLReponseCandidat,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(prmDTO)
      }
    )
  }



}

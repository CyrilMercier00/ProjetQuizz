import { Component, Input, OnInit, Output } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { Router } from '@angular/router';
import { VariableGlobales } from 'src/app/url_api';
import { reponseDTO } from '../../../DTO/reponseDTO';

@Component({
  selector: 'app-page-reponse-qcm',
  templateUrl: './page-reponse-qcm.component.html',
  styleUrls: ['./page-reponse-qcm.component.css', '../../../app.flex-util.css']
})
export class PageReponseQcmComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  @Input("dataQuestion") dataQ: DTOQuestion[];
  @Input("dataReponses") dataR;
  rep1: string;
  rep2: string;
  rep3: string;
  rep4: string;
  textCommentaire: string;
  nbQuestionTotal: number;
  nbQuestionActu: number;
  idQuestion: number;
  enonce: string;

  /* ------ Constructeur ------ */
  constructor(private router: Router)
  {
    this.dataQ.forEach((data) =>{
    this.enonce = data.enonce;
    })
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {

  }



  /* ------ Methodes ------*/
  handleBtnClick(event)
  {
    let data = new reponseDTO();

    data._Commentaire = this.textCommentaire;
    data._Reponse = event.target.value;
    data._FKCompte = 0;
    data._FKQuestion = parseInt(this.router.getCurrentNavigation().extras.state["fkQuestion"]);

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

import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from 'src/app/url_api';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { reponseDTO } from '../../../DTO/reponseDTO';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-reponse-qcm',
  templateUrl: './page-reponse-qcm.component.html',
  styleUrls: ['./page-reponse-qcm.component.css', '../../../app.flex-util.css']
})
export class PageReponseQcmComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  rep1: string;
  rep2: string;
  rep3: string;
  rep4: string;
  textCommentaire: string;
  nbQuestionTotal: number;
  nbQuestionActu: number;
  idQuestion: number;
  valRetourRequeteGETQuestion: any;

  /* ------ Constructeur ------ */
  constructor(private router: Router)
  {

  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
    this.getQuestions(this.idQuestion);
  }



  /* ------ Methodes ------*/
  handleBtnClick(event) 
  {
    let data = new reponseDTO();  

    data._Commentaire = this.textCommentaire;
    data._Reponse = event.target.value;
    data._FKCompte = this.getIDCommpte();
    data._FKQuestion = parseInt(this.router.getCurrentNavigation().extras.state["fkQuestion"]);
    
    this.envoiFormulaire(data);
  }



  /* --- GET des reponses possibles pour cette question --- */
  async getQuestions(prmIDQuestion: number)
  {
    await fetch(VariableGlobales.apiURLQuestion + "/" + this.idQuestion, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteGETQuestion = json;
      });
  }



  /* --- GET id de la session actuelle --- */
  getIDCommpte(): number
  {
    return 1;
  }


  /* --- POST de la reponse choisie --- */
  async envoiFormulaire(prmDTO: reponseDTO)
  {

    {
      await fetch(
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
}

import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-formulaire-creation-question',
  templateUrl: './formulaire-creation-question.component.html',
  styleUrls: ['./formulaire-creation-question.component.css']
})



export class FormulaireAjoutQuestionBddComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  @Output("valForm") valForm: FormData;
  resultatForm: FormGroup;



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder)
  {
    this.resultatForm = this.builder.group
      ({
        texteQuestion: ['', Validators.required],
        theme: ['', Validators.required],
        complexite: ['', Validators.required],
        repLibre: ["false"],
      })
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
  }



  /* ------ Methodes ------ */
  handleSubmit()
  {
    this.InsertQuestion(this.resultatForm);
  }



  /* --- Set de la valeur enoncé si changement dans le select --- */
  setValeurEnonce(prmValue: string)
  {
    this.resultatForm.patchValue({ "texteQuestion": prmValue });
  }



  setValeurFormLibre(prmValue: string)
  {
    this.resultatForm.patchValue({ "repLibre": prmValue });
    console.log(this.resultatForm);
  }



  /* --- Set de la niveau enoncé si changement dans le select --- */
  setValeurFormNiveau(prmValue: string)
  {
    this.resultatForm.patchValue({ "complexite": prmValue });
  }



  /* --- Set de la valeur theme si changement dans le select --- */
  setValeurFormTheme(prmValue: string)
  {
    this.resultatForm.patchValue({ "theme": prmValue });
  }



  /* --- Envoi a l'api de la question ---*/
  InsertQuestion(data)
  {

    let q = new DTOQuestion();
    q.$Enonce = data.value.texteQuestion;
    q.$RepLibre = data.value.repLibre;
    q.$complexite = data.value.complexite;
    q.$Theme = data.value.theme;

    fetch(
      VariableGlobales.apiURLQuestion,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(q)
      }
    )
  }


}



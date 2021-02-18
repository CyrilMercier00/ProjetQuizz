import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-formulaire-creation-question',
  templateUrl: './formulaire-creation-question.component.html',
  styleUrls: ['./formulaire-creation-question.component.css']
})



export class FormulaireAjoutQuestionBddComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  resultatForm: FormGroup;



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder) 
  {
    this.resultatForm = this.builder.group
      ({
        texteQuestion: ['', Validators.required],
        theme: ['', Validators.required],
        complexite: ['', Validators.required],
        repLibre: ['', Validators.required],
      })
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
  }



  /* ------ Methodes ------ */
  setValeurEnonce(prmValue: string)
  {
    this.resultatForm.patchValue({ "texteQuestion": prmValue });
  }


}




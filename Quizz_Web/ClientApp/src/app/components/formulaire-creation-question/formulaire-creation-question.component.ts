import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-formulaire-creation-question',
  templateUrl: './formulaire-creation-question.component.html',
  styleUrls: ['./formulaire-creation-question.component.css']
})



export class FormulaireAjoutQuestionBddComponent implements OnInit
{

  resultatForm: FormGroup;




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




  ngOnInit()
  {
  }

}

import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../../../url_api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from "@angular/router"



@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: ['./gen-quizz.component.css', '../../app.flex-util.css']
})



export class GenQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  resultatForm: FormGroup;                      // Contiens le formulaire de creation de quizz



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder, private router: Router)
  {
    this.resultatForm = this.builder.group
      ({
        nbQuestions: ['', Validators.required],
        theme: ['', Validators.required],
        complexite: ['', Validators.required]
      })
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
  }


  /* ------ Fonctions ------ */
  /* --- Change la valeur du formulaire local avec la valeur passée par l'enfant --- */
  setValeurFormTheme(prmValue: string)
  {
    this.resultatForm.patchValue({ "theme": prmValue });
  }



  setValeurFormNiveau(prmValue: string)
  {
    this.resultatForm.patchValue({ "complexite": prmValue });
  }


  setValeurFormNbQ(prmValue: number) 
  {
    this.resultatForm.patchValue({ "nbQuestions": prmValue });
  }



  /* --- Envoie a la page suivante avec les données du formulaire --- */
  onSubmit()
  {
    this.router.navigate(['/assign-quizz'], { state: { c: this.resultatForm.value} });
  }
}

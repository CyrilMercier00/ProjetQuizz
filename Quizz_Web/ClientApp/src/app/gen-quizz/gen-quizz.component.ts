/*
------------------------------------------------------------
    TODO : Recup de l'id du compte & l'envoyer avec le quizz
------------------------------------------------------------
*/
import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../url_api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from "@angular/router"



@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})



export class GenQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  idCompte = this.getCompteID();                // ID du compte utilisateur
  resultatForm: FormGroup;                      // Contiens le formulaire de creation de quizz
  valRetourRequeteTheme$: Observable<any>;;     // Contiens le retour de la requete theme
  valRetourRequeteComplex$: Observable<any>;    // Contiens le retour de la requete complexite



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder, private router: Router)
  {
    this.resultatForm = this.builder.group
      ({
        nbQuestions: [ '', Validators.required ],
        theme: [ '', Validators.required ],
        complexite: [ '', Validators.required ]
      })
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    this.setValeursAFfichage();
  }


  /* ------ Fonctions ------ */
  /* --- Fonction maj form manuelle pour les select --- */
  themeUpdate(prmEvent)
  {
    this.resultatForm.patchValue({ "theme": prmEvent.target.value });
  }



  complexUpdate(prmEvent)
  {
    this.resultatForm.patchValue({ "complexite": prmEvent.target.value });
  }



  /* --- Insertion des valeurs dans les balises select --- */
  setValeursAFfichage()
  {
    try
    {
      this.getAllTheme();
      this.getAllComplexite();
    } catch (e)
    {
      console.log(e.message);
    }
  }



  /* ---  Retourne l'id du compte qui a créer le quizz --- */
  getCompteID()
  { /* ---------- TODO ---------- */
    return 1;
  }



  /* --- Envoie a la page suivante avec les données du formulaire --- */
  onSubmit()
  {
    this.router.navigate([ '/assign-quizz' ], { state: { formValue : this.resultatForm.value, idCompte: this.idCompte } });
  }



  /* ------ Fonctions acces api ------ */
  /* --- Retourne le json des themes disponibles--- */
  getAllTheme()
  {
    fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteTheme$ = JSON.parse(JSON.stringify(json));
      });
  }



  /* -- Retourne le json des complexites disponibles --- */
  getAllComplexite()
  {
    let reponse = fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex$ = JSON.parse(JSON.stringify(json));
      });
  }




}

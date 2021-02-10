import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../url_api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})
export class GenQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  idCompte = this.getCompteID();    // ID du compte utilisateur
  resultatForm: FormGroup;          // Contiens les valeurs du formulaire de creation
  valRetourRequeteTheme;            // Contiens le retour de la requete theme
  valRetourRequeteComplex;          // Contiens le retour de la requete complexite



  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder)
  {
    this.resultatForm = this.builder.group
      ({
        nbQuestions: [ '', Validators.required ],
        theme: [ '', Validators.required ],
        complexite: [ '', Validators.required ]
      })
  }



  ngOnInit()
  {
    this.setValeursAFfichage();
  }



  /* --- Maj manuelle necessaire pour utiliser un select --- */
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



  // Retourne l'id du compte qui a créer le quizz
  getCompteID()
  {
    return 1;
  }



  onSubmit()
  {
    this.creerQuizz(this.resultatForm.value)
  }



  // Insertion du quizz & gestion erreur
  creerQuizz(prmDataQuizz: string)
  {
    try
    {

      this.insertQuizz(prmDataQuizz);

    } catch (e)
    {
      console.log(e);
    }
  }



  /* ------ Fonctions acces api ------ */
  /* --- Envoie a l'api pour insertion du quizz ---*/
  async insertQuizz(data: string)
  {
    console.log("InsertQuizz: " + data);
    let reponse = await fetch(VariableGlobales.apiURLQuizz,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      }
    )
    await reponse;
  }



  /* --- Retourne le json des themes disponibles--- */
  getAllTheme()
  {
    fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteTheme = JSON.parse(JSON.stringify(json));
      });
  }



  /* -- Retourne le json des complexites disponibles --- */
  getAllComplexite()
  {
    let reponse = fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex = JSON.parse(JSON.stringify(json));
      });
  }

}

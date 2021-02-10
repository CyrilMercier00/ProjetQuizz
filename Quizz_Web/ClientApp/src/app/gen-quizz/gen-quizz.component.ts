import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../url_api';
import { Quizz } from "../DTO/quizzDTO"
import { JsonpClientBackend } from '@angular/common/http';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})
export class GenQuizzComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  idCompte = this.getCompteID();    // ID du compte utilisateur
  inputNbQuestion = 0;              // Nombre de questions affiché dans l'input
  inputTheme = "c#";                //
  inputComplexite = "Débutant";     //
  quizz = new Quizz();              // Le DTO du quizz qui va etre envoyé a l'api
  valRetourRequeteTheme;            // Contiens le retour de la requete theme
  valRetourRequeteComplex;          // Contiens le retour de la requete complexite




  /* ------ Constructeur ------ */
  constructor() { }

  ngOnInit()
  {
    this.setValeursAFfichage();
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




  /* ------ Fonctions acces api ------ */
  /* --- Envoie du DTO local a l'api pour insertion du quizz ---*/
  CreerQuizz()
  {
    console.log("Creer quizz");
  }



  /* --- Retourne le json des themes disponibles--- */
  async getAllTheme()
  {
    let reponse = await fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteTheme = JSON.parse(JSON.stringify(json));
      });
    return reponse;
  }



  /* -- Retourne le json des complexites disponibles --- */
  async getAllComplexite()
  {
    let reponse = await fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex = JSON.parse(JSON.stringify(json));
      });
  }

}

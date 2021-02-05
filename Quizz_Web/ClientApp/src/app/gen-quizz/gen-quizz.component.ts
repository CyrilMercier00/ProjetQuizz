import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../globales';
import { Quizz } from "../DTO/quizzDTO"

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: ['./gen-quizz.component.css', '../app.flex-util.css']
})
export class GenQuizzComponent implements OnInit {

  urlGetTheme = VariableGlobales.apiURL + "theme";
  urlGetComplexite = VariableGlobales.apiURL + "niveau";
  urlPostQuizz = VariableGlobales.apiURL + "quizz"

  idCompte = this.getCompteID();    // ID du compte utilisateur
  inputNbQuestion = 0;              // Nombre de questions affiché dans l'input
  inputTheme = "c#";                //
  inputComplexite = "Débutant";     //
  quizz = new Quizz();              // Le DTO du quizz qui va etre envoyé a l'api
  valRetourRequete;                 // Contiens le retour des requetes

  constructor() {
    this.setValeursAFfichage();
  }

  ngOnInit() {
  }


  setValeursAFfichage() {

    this.valRetourRequete = this.getAllTheme();
    this.valRetourRequete = this.getAllComplexite();



  }

  getCompteID() {
    return 1;
  }

  /* --- Fonctions acces api --- */
  getAllTheme() {

    let reponse = fetch(this.urlGetTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) => {
        return json;
      });
  }

  getAllComplexite() {

    let reponse = fetch(this.urlGetComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) => {
        return json;
      });
  }

  CreerQuizz() {
    console.log("Creer quizz");
  }

}

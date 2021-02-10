import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../globales';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})
export class GenQuizzComponent implements OnInit
{

  urlGetTheme = VariableGlobales.apiURL + "theme";
  urlGetComplexite = VariableGlobales.apiURL + "niveau";
  urlPostQuizz = VariableGlobales.apiURL + "quizz"

  inputNbQuestion = 0;
  inputTheme = "c#";
  inputComplexite = "Débutant";
  inputTemps = "Débutant";

  constructor() { }

  ngOnInit()
  {
    this.getAllTheme();
    this.getAllComplexite();



  }

  async getAllTheme()
  {

    let reponse = await fetch(this.urlGetTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        console.log(json);
      });

  }

  async getAllComplexite()
  {

    let reponse = await fetch(this.urlGetComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        console.log(json);
      });

  }

  CreerQuizz()
  {
    console.log("Creer quizz");
  }

}

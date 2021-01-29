import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../globales';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: ['./gen-quizz.component.css', '../app.flex-util.css']
})
export class GenQuizzComponent implements OnInit {

  urlGetTheme = VariableGlobales.apiURL + "/themes";
  urlGetComplexite = VariableGlobales.apiURL + "/niveau";
  inputNbQuestion = 0;
  inputTheme = "c#";
  inputComplexite = "Débutant";

  constructor() { }

  ngOnInit() {
  }

  getAllTheme() {

    let reponse = fetch(this.urlGetTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) => {
        console.log(json);
      });

  }

  getAllComplexite() {

    let reponse = fetch(this.urlGetComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) => {
        console.log(json);
      });

  }

  CreerQuizz() {
    console.log("Creer quizz");
  }

}

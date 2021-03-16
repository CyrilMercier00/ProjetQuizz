import { Component, OnInit } from '@angular/core';
import { Globals } from 'src/app/globals';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-liste-quizz',
  templateUrl: './liste-quizz.component.html',
  styleUrls: ['./liste-quizz.component.css']
})
export class ListeQuizzComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.initListeQuizz();
  }

  private initListeQuizz(): void {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    fetch(
      VariableGlobales.apiURLQuizz + Globals.getId(),
      {
        method: "GET",
        headers: requestHeaders
      }
    ).then(response => console.log(response.json()));
  }
}

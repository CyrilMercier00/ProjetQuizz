import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';



@Component({
  selector: 'app-select-niveau',
  templateUrl: './select-niveau.component.html',
  styleUrls: ['./select-niveau.component.css']
})



export class SelectNiveauComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteComplex$: Observable<string>;   // Retour de la requete GET faite a l'api
  @Output() ChoixEvent = new EventEmitter();      // Contiens la valeur choisie dans le select



  /* ------ Constructeurs ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
  }



  /* ------ Fonctions ------ */
  /* --- Maj output --- */
  complexUpdate(prmEvent)
  {
    this.ChoixEvent = prmEvent.target.value;
    this.ChoixEvent.emit;
  }



  /* --- Fetch de la complexité a la bdd --- */
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

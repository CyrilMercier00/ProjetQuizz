import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VariableGlobales } from 'src/app/url_api';
import { Compte } from '../../../compte-feature/Compte/compte.model'
import { Globals } from '../../../globals'



@Component({
  selector: 'app-select-compte-candidat',
  templateUrl: './select-compte-candidat.component.html',
  styleUrls: ['./select-compte-candidat.component.css']
})



export class SelectCompteCandidatComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteCompteAssigne: Compte[] = [];    // Contiens le retour de la requete get all compte assigne au recruteur
  @Output() ChoixEvent = new EventEmitter<string>();


  /* ------ Constructeur ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit(): void
  {
    this.getCandidatAsigne();
  }



  /* ------ Methodes ------ */
  IDUpdate(id) 
  {
    this.ChoixEvent.emit(id);
  }



  /* --- Get des candidats assignés a ce recruteur --- */
   getCandidatAsigne()
  {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

     fetch(VariableGlobales.apiURLCompte, { method: "GET", headers: requestHeaders })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteCompteAssigne = json;
      });
  }

}

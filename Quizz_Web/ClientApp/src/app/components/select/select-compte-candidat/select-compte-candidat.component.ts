import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VariableGlobales } from 'src/app/url_api';



@Component({
  selector: 'app-select-compte-candidat',
  templateUrl: './select-compte-candidat.component.html',
  styleUrls: ['./select-compte-candidat.component.css']
})



export class SelectCompteCandidatComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteCompteAssigne: string;    // Contiens le retour de la requete get all compte assigne au recruteur
  @Output() ChoixEvent = new EventEmitter<string>();


  /* ------ Constructeur ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit(): void
  {
    this.getCandidatAsigne();
  }



  /* ------ Methodes ------ */
  IDUpdate(prmEvent) 
  {
    this.ChoixEvent.emit(prmEvent.value);
  }



  /* --- Get des candidats assignés a ce recruteur --- */
  async getCandidatAsigne()
  {
    await fetch(VariableGlobales.apiURLCompte + "1" + "/Candidat", { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteCompteAssigne = json;
      });
  }

}

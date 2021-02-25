import { Component, OnInit } from '@angular/core';
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



  /* ------ Constructeur ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit(): void
  {
    this.getCandidatAsigne();
    console.log(this.valRetourRequeteCompteAssigne);
  }



  /* ------ Fonctions ------ */
  /* --- Get des candidats aassigné a ce recruteur --- */
  async getCandidatAsigne()
  {
    const reponse = await fetch(VariableGlobales.apiURLCompte + "1" + "/Candidat", { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteCompteAssigne = json;
      });
    return reponse
  }

}

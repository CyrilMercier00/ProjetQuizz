import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VariableGlobales } from 'src/app/url_api';



@Component({
  selector: 'app-select-niveau',
  templateUrl: './select-niveau.component.html',
  styleUrls: ['./select-niveau.component.css']
})



export class SelectNiveauComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteComplex: string;                        // Retour de la requete GET faite a l'api
  @Output() ChoixEvent = new EventEmitter<string>();      // Emit si la valeur dans le select change


  /* ------ Constructeurs ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    this.getAllComplexite();
  }



  /* ------ Fonctions ------ */
  /* --- Emit si (onChange) est trigger --- */
  complexUpdate(prmEvent)
  {
    this.ChoixEvent.emit(prmEvent.target.value);
  }



  /* --- Fetch de la complexité a la bdd --- */
  getAllComplexite()
  {
    fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex = JSON.parse(JSON.stringify(json));
      });
  }
}

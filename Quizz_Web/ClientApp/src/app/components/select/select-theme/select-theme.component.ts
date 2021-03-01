import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-select-theme',
  templateUrl: './select-theme.component.html',
  styleUrls: ['./select-theme.component.css']
})



export class SelectThemeComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  valRetourRequeteTheme: string;                                        // Retour de la requete GET faite a l'api
  @Output() ChoixEvent = new EventEmitter<string>();      // Emit si la valeur dans le select change


  /* ------ Constructeurs ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    this.getAllTheme();
  }



  /* ------ Fonctions ------ */
  /* --- Emit si (onChange) est trigger --- */
  themeUpdate(prmEvent)
  {
    this.ChoixEvent.emit(prmEvent.target.value);
  }



  /* -- Retourne le json des themes disponibles--- */
  async getAllTheme()
  {
    console.log(VariableGlobales.apiURLTheme);
    await fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteTheme = json;
      });
  }
}

import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'events';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-select-theme',
  templateUrl: './select-theme.component.html',
  styleUrls: [ './select-theme.component.css' ]
})
export class SelectThemeComponent implements OnInit
{

  valRetourRequeteTheme$: Observable<string>;
  @Output() valChoisie = new EventEmitter();

  constructor() { }

  ngOnInit()
  {
    this.getAllTheme();
  }

  getAllTheme()
  {
    fetch(VariableGlobales.apiURLTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteTheme$ = JSON.parse(JSON.stringify(json));
      });
  }

  themeUpdate(prmEvent)
  {
    this.valChoisie = prmEvent.target.value;
  }

}

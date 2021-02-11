import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-select-niveau',
  templateUrl: './select-niveau.component.html',
  styleUrls: [ './select-niveau.component.css' ]
})
export class SelectNiveauComponent implements OnInit
{
  valRetourRequeteComplex$: Observable<string>;
  @Output() valChoisie = new EventEmitter();

  constructor() { }



  ngOnInit()
  {
  }


  complexUpdate(prmEvent)
  {
    this.valChoisie = prmEvent.target.value;
  }



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

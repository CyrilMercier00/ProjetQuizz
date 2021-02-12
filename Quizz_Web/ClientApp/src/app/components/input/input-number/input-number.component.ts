import { Component, EventEmitter, OnInit, Output } from '@angular/core';



@Component({
  selector: 'app-input-number',
  templateUrl: './input-number.component.html',
  styleUrls: ['./input-number.component.css']
})



export class InputNumberComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  @Output() NumberChangeEvent = new EventEmitter<number>();



  /* ------ Constructeurs ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit(): void { }



  /* ------ Fonctions ------ */
  numberUpdate(prmEvent)
  {
    this.NumberChangeEvent.emit(prmEvent.target.value);
  }
}

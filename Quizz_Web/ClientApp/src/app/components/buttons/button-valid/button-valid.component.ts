import { Component, Input, OnInit } from '@angular/core';



@Component({
  selector: 'app-button-valid',
  templateUrl: './button-valid.component.html',
  styleUrls: ['./button-valid.component.css']
})



export class ButtonValidComponent implements OnInit
{
  /* ------ Declaration des variables ------ */
  @Input("isDisabled") isDisabled: boolean = false;



  /* ------ Constructeur ------ */
  constructor() { }



  /* --- Methodes Angular --- */
  ngOnInit(): void
  {
  }
}

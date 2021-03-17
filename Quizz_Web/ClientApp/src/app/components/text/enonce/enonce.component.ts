import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-enonce',
  templateUrl: './enonce.component.html',
  styleUrls: ['./enonce.component.css']
})



export class EnonceComponent implements OnInit
{

  /* --- Variables --- */
  @Input("text") text: string;




  /* --- Constructeur --- */
  constructor() {}



  /* --- Methodes Angular --- */
  ngOnInit()
  {

  }



  /* --- Methodes --- */



}

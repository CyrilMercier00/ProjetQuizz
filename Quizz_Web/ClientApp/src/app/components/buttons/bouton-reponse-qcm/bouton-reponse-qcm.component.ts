import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bouton-reponse-qcm',
  templateUrl: './bouton-reponse-qcm.component.html',
  styleUrls: ['./bouton-reponse-qcm.component.css']
})
export class BoutonReponseQcmComponent implements OnInit
{
  @Input("text") text: string;
  @Input("ID") idBtn: number;



  constructor() { }



  ngOnInit()
  {
  }




  onclick()
  {
    // TODO : Emmetre l'id de la question choisie
  }
}

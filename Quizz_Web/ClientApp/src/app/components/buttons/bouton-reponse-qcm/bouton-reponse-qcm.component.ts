import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-bouton-reponse-qcm',
  templateUrl: './bouton-reponse-qcm.component.html',
  styleUrls: ['./bouton-reponse-qcm.component.css']
})
export class BoutonReponseQcmComponent implements OnInit
{
  @Input("text") text: string;
  @Input("ID") idBtn: number;
  @Output("ID") emitterID = new EventEmitter()



  constructor() { }



  ngOnInit()
  {
  }



  onclick()
  {
    this.emitterID.emit(this.idBtn);
  }

}

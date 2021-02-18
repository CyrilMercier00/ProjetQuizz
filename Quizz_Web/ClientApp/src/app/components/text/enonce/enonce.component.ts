import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-enonce',
  templateUrl: './enonce.component.html',
  styleUrls: ['./enonce.component.css']
})
export class EnonceComponent implements OnInit
{

  @Input("texte") text: string;

  constructor() { }

  ngOnInit()
  {
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-reponse-qcm',
  templateUrl: './page-reponse-qcm.component.html',
  styleUrls: ['./page-reponse-qcm.component.css']
})
export class PageReponseQcmComponent implements OnInit
{

  rep1: string ;
  rep2: string;
  rep3: string;
  rep4: string ;

  constructor() { }

  ngOnInit()
  {
  }

}

import { Component, Input, OnInit } from '@angular/core';

import { questionDTO } from 'src/app/DTO/questionDTO';

@Component({
  selector: 'app-page-reponse-libre',
  templateUrl: './page-reponse-libre.component.html',
  styleUrls: ['./page-reponse-libre.component.css']
})
export class PageReponseLibreComponent implements OnInit
{
  @Input("dataQuestion") data: any;

  constructor() { }

  ngOnInit()
  {
  }

}

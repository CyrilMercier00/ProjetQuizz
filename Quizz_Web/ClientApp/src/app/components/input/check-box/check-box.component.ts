import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-check-box',
  templateUrl: './check-box.component.html',
  styleUrls: ['./check-box.component.css', '../../../app.flex-util.css']
})



export class CheckBoxComponent implements OnInit
{

  @Input("titre") titre = "Réponse libre";



  
  constructor() { }




  ngOnInit()
  {
  }

}

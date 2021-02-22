import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-page-debut-quizz',
  templateUrl: './page-debut-quizz.component.html',
  styleUrls: ['./page-debut-quizz.component.css', '../../../app.flex-util.css']
})



export class PageDebutQuizzComponent implements OnInit
{
  /* --- Variables --- */



  /* --- Constructeur ---*/
  constructor(private router: Router) { }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
  }



  /*--- Methodes ---*/
  handleClick()
  {
    this.router.navigate([''])
  }


  GetQuizz(prmID)
  {
    
  }

}

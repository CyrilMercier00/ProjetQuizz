import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { VariableGlobales } from 'src/app/url_api';



@Component({
  selector: 'app-page-debut-quizz',
  templateUrl: './page-debut-quizz.component.html',
  styleUrls: ['./page-debut-quizz.component.css', '../../../app.flex-util.css']
})



export class PageDebutQuizzComponent implements OnInit
{
  /* --- Variables --- */
  prmCode: any;
  valRetourRequeteQuestions: any;
  Quizz :any ;



  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute)
  {
    this.prmCode = this.actRoute.snapshot.params['urlQuizz'];  
  }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
    console.log(this.prmCode);
  }


  
  /*--- Methodes ---*/
  handleClick()
  {
    this.router.navigate([''])
  }




  questionToArray(prmData ) 
  {
    
  }



   GetQuizz(prmCode)
  {
     fetch(VariableGlobales.apiURLQuizz + "/" + prmCode , { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.Quizz = json;
      });
  }



   GetQuestions()
  {
     fetch(VariableGlobales.apiURLQuestion + "/" + this.Quizz.pkQuizz { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.questionToArray(json);
      });
  }

}

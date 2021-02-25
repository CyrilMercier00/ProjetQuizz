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
  codeQuizz: any;
  valRetourRequeteQuestions: any;



  /* --- Constructeur ---*/
  constructor(private router: Router, private actRoute: ActivatedRoute)
  {
    this.codeQuizz = this.actRoute.snapshot.params['urlQuizz'];   // Recup de de l'url du
  }


  /* --- Methodes Angular --- */
  ngOnInit()
  {
    console.log(this.codeQuizz);
  }



  /*--- Methodes ---*/
  handleClick()
  {
    this.router.navigate([''])
  }



  questionToArray(prmData ) 
  {
    
  }




  async GetQuestions(prmID)
  {

    await fetch(VariableGlobales.apiURLQuestion + "/" + prmID, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.questionToArray(json);
      });
  }

}

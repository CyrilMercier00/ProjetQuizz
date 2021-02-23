import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { VariableGlobales } from 'src/app/url_api';



@Component({
  selector: 'app-page-debut-quizz',
  templateUrl: './page-debut-quizz.component.html',
  styleUrls: ['./page-debut-quizz.component.css', '../../../app.flex-util.css']
})



export class PageDebutQuizzComponent implements OnInit
{
  /* --- Variables --- */
  codeQuizz = this.route.params.subscribe(params => { return params.urlQuizz });
  valRetourRequeteQuestions : any ;



  /* --- Constructeur ---*/
  constructor(private router: Router, private route: ActivatedRoute) { }



  /* --- Methodes Angular --- */
  ngOnInit()
  {
  }



  /*--- Methodes ---*/
  handleClick()
  {
    this.router.navigate([''])
  }


  async GetQuestions(prmID)
  {

    await fetch(VariableGlobales.apiURLQuestion + "/" + prmID, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteQuestions = json;
      });
  }

}

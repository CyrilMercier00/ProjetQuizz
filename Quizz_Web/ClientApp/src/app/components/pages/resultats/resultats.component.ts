import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { utils } from 'protractor';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';

@Component({
  selector: 'app-resultats',
  templateUrl: './resultats.component.html',
  styleUrls: ['./resultats.component.css']
})
export class ResultatsComponent implements OnInit {

    /* --- Variables --- */
    code: string;
  
    //******************/
  
    
    quizz:DTOQuizz;
    TimeQ;
    
    
    /* --- Constructeur ---*/
    constructor(private router: Router, private actRoute: ActivatedRoute)
    {
      this.code = this.actRoute.snapshot.params['urlQuizz'];
    }

  ngOnInit() {
   
  }

}

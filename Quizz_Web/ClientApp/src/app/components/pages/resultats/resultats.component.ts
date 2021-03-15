import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { utils } from 'protractor';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';
import { ServiceQuizz } from 'src/app/Service/serviceQuizz';
import { ChronoComponent } from '../../chrono/chrono.component';

@Component({
  selector: 'app-resultats',
  templateUrl: './resultats.component.html',
  styleUrls: ['./resultats.component.css']
})

//@ViewChild(ChronoComponent)

export class ResultatsComponent implements OnInit {

  
 
  private chronoComponent: ChronoComponent;

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
    ServiceQuizz.ValidateQuizz(this.code);
  }
  
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-formulaire-creation-niveau',
  templateUrl: './formulaire-creation-niveau.component.html',
  styleUrls: ['./formulaire-creation-niveau.component.css']
})
export class FormulaireCreationNiveauComponent implements OnInit {
@httpPos
  
niveauForm :  FormGroup;
  constructor( private fb :FormBuilder) { 
this.niveauForm=this.fb.group({
  Niveau :[""],
  questionjunior: [0],
  questionconfirme:[0],
  questionexperimente:[0]

});

  }

  ngOnInit(): void {
  }
  onSubmit(): void{
   
  }
}

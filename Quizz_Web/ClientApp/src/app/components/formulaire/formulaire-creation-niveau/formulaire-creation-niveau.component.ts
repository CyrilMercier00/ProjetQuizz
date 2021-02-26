import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-formulaire-creation-niveau',
  templateUrl: './formulaire-creation-niveau.component.html',
  styleUrls: ['./formulaire-creation-niveau.component.css']
})
export class FormulaireCreationNiveauComponent implements OnInit {

  constructor( private fb :FormBuilder) { 
    
  }

  ngOnInit(): void {
  }

}

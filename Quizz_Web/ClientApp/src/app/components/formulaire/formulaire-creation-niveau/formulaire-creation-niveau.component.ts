import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-formulaire-creation-niveau',
  templateUrl: './formulaire-creation-niveau.component.html',
  styleUrls: ['./formulaire-creation-niveau.component.css']
})
export class FormulaireCreationNiveauComponent implements OnInit {
  
niveauForm :  FormGroup;

  constructor( private fb :FormBuilder) { 
    
this.niveauForm=this.fb.group({
  Niveau :[""],
  QuestionJunior: [0],
  QuestionConfirme:[0],
  QuestionExperimente:[0]

});


  }

  ngOnInit(): void {
  }
  onSubmit(): void{
console.log(this.niveauForm.value)
  }
  
      async envoiFormulaire()
      {
    
        {
          await fetch(
            VariableGlobales.apiURLReponseCandidat,
            {
              method: "POST",
              headers:
              {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              },
              body: JSON.stringify(this.niveauForm.value )
            }
          )
        }
}
}


import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { VariableGlobales } from "src/app/url_api";

@Component({
  selector: "app-formulaire-creation-niveau",
  templateUrl: "./formulaire-creation-niveau.component.html",
  styleUrls: ["./formulaire-creation-niveau.component.css"],
})
export class FormulaireCreationNiveauComponent implements OnInit {
  niveauForm: FormGroup;
  isValid = true;

  constructor(private fb: FormBuilder) {
    this.niveauForm = this.fb.group({
      Niveau: ["",Validators.required],
      QuestionJunior: [0,Validators.required],
      QuestionConfirme: [0,Validators.required],
      QuestionExperimente: [0,Validators.required],
    });
  }

  ngOnInit(): void {}
  onSubmit(): void {
    console.log(this.niveauForm.value);
    console.log(this.pourcent());
  }

  async envoiFormulaire() {
    {
      await fetch(VariableGlobales.apiURLReponseCandidat, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.niveauForm.value),
      });
    }
  }
  

  pourcent(): boolean {
    let isOk=true;
    let pr =
      this.niveauForm.value.QuestionJunior +
      this.niveauForm.value.QuestionConfirme +
      this.niveauForm.value.QuestionExperimente;
    if (pr == 100) {
     isOk= false;
      
    } 
    return isOk;
  }
}

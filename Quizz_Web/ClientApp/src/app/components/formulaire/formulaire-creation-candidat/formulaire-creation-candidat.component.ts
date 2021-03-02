import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Compte } from 'src/app/compte-feature/Compte/compte.model';

@Component({
  selector: 'app-formulaire-creation-candidat',
  templateUrl: './formulaire-creation-candidat.component.html',
  styleUrls: ['./formulaire-creation-candidat.component.css']
})
export class FormulaireCreationCandidatComponent implements OnInit {
  @Output() compteToSend = new EventEmitter<Compte>();
  @Input() inOut;
  candidatProfile: FormGroup;

  constructor(private fb: FormBuilder) {
    this.candidatProfile = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      mail: ['', Validators.required],
    
    });
   }
  ngOnInit() {
  }
  onSubmit(): void{
    this.inOut = false;
    //this.candidatProfile.patchValue({role: 3});
    this.compteToSend.emit(this.candidatProfile.value);
  }
}

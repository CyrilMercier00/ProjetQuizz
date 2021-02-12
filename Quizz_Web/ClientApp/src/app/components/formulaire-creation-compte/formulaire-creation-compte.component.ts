import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Compte } from 'src/app/compte-feature/Compte/compte.model';

@Component({
  selector: 'app-formulaire-creation-compte',
  templateUrl: './formulaire-creation-compte.component.html',
  styleUrls: ['./formulaire-creation-compte.component.css']
})
export class FormulaireCreationCompteComponent implements OnInit {

  @Output() compteToSend = new EventEmitter<Compte>();
  compteProfile : FormGroup;

  constructor(private fb: FormBuilder) {
    this.compteProfile = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      mail: ['', Validators.required],
      mdp: ['', Validators.required],
      role: [0, Validators.required]
    });
   }

  ngOnInit(): void {
  }

  onSubmit(): void{
    this.compteToSend.emit(this.compteProfile.value);
  }

}

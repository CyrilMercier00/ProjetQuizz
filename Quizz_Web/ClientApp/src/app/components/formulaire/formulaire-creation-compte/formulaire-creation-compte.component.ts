import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Compte } from 'src/app/compte-feature/Compte/compte.model';
import { trigger, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-formulaire-creation-compte',
  templateUrl: './formulaire-creation-compte.component.html',
  styleUrls: ['./formulaire-creation-compte.component.css'],
  animations: [
    trigger('flyInOut', [
      
      transition(':enter', [
        style({transform: 'translateX(100%)', opacity: 0}),
        animate('600ms', style({transform: 'translateX(0)', opacity: 1}))
      ]),
      transition(':leave', [
        style({transform: 'translateX(0)', 'opacity': 1}),
        animate('600ms', style({transform: 'translateX(100%)', opacity: 0}))
      ])
    ])
  ]
})
export class FormulaireCreationCompteComponent implements OnInit {

  @Output() compteToSend = new EventEmitter<Compte>();
  @Input() inOut;
  compteProfile : FormGroup;

  constructor(private fb: FormBuilder) {
    this.compteProfile = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      mail: ['', Validators.required],
      mdp: ['', Validators.required],
      role: [0]
    });
   }

  ngOnInit(): void {
  }

  onSubmit(): void{
    this.inOut = false;
    this.compteProfile.patchValue({role: 3});
    this.compteToSend.emit(this.compteProfile.value);
  }

}

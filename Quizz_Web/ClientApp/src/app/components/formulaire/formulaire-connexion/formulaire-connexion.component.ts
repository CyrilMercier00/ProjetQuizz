import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConnexionDTO } from 'src/app/DTO/ConnexionDTO';

@Component({
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrls: ['./formulaire-connexion.component.css']
})
export class FormulaireConnexionComponent implements OnInit {

  @Output() clickToSend = new EventEmitter<boolean>();
  @Output() connexionEmitter = new EventEmitter<ConnexionDTO>();
  @Output() deconnexionEvent = new EventEmitter();
  @Input() isCreationOpen: boolean = false;

  compteConnexion: FormGroup;

  constructor(private fb: FormBuilder) {
    this.compteConnexion = this.fb.group({
      mail: ['', Validators.required],
      MotDePasse: ['', Validators.required]
    });
   }

  ngOnInit(): void {
    
  }

  changeBoolean(): void{
    this.isCreationOpen = !this.isCreationOpen;
  }

  emitClick(): void{
    this.changeBoolean();
    this.clickToSend.emit(this.isCreationOpen);
  }

  onSubmit(): void{
    this.connexionEmitter.emit(this.compteConnexion.value);
  }

  logout(): void{
    this.deconnexionEvent.emit();
  }
}

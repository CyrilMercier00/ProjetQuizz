import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrls: ['./formulaire-connexion.component.css']
})
export class FormulaireConnexionComponent implements OnInit {

  @Output() clickToSend = new EventEmitter<boolean>();
  @Input() isCreationOpen: boolean = false;

  constructor() { }

  ngOnInit(): void {
    
  }

  changeBoolean(): void{
    this.isCreationOpen = !this.isCreationOpen;
  }

  emitClick(): void{
    this.changeBoolean();
    this.clickToSend.emit(this.isCreationOpen);
  }
}

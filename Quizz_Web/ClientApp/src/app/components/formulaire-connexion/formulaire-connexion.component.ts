import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrls: ['./formulaire-connexion.component.css']
})
export class FormulaireConnexionComponent implements OnInit {

  @Output() clickToSend = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  isOpen = false;

  changeBoolean(){
    this.isOpen = !this.isOpen;
    this.clickToSend.emit(this.isOpen);
  }
}

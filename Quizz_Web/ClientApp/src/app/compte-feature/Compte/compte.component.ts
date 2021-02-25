import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Compte } from './compte.model';
import { CompteService } from './compte.service';

@Component({
  selector: 'app-compte',
  templateUrl: './compte.component.html',
  styleUrls: ['./compte.component.css']
})
export class CompteComponent implements OnInit {

  @Input() compte : Compte;
  @Output() refreshEvent = new EventEmitter();
  modifying: boolean = false;
  
  constructor(private compteService: CompteService) {
  }

  ngOnInit(): void {
  }

  modifyPermission(): void{
    
  }

  supprimerCompte(): void{
    this.compteService.delete(this.compte).subscribe(response => {
      console.log('Le compte ' + this.compte.nom + ' a été supprimé.');
      this.refreshEvent.emit();
    });;
  }

}

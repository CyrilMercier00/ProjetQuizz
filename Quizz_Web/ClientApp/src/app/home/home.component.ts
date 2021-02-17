import { Component, Output } from '@angular/core';
import { Router } from '@angular/router';
import { EventEmitter } from 'events';
import { Compte } from '../compte-feature/Compte/compte.model';
import { CompteService } from '../compte-feature/Compte/compte.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
  public constructor(private router : Router, private compteService: CompteService){}

  redirectToHome(){
    this.router.navigate(['/']);
  }

  isOpen = false;

  onClick(click: boolean){
    this.isOpen = click;
  }

  recupCompte(compte: Compte){
    this.compteService.create(compte).subscribe();
  }
}

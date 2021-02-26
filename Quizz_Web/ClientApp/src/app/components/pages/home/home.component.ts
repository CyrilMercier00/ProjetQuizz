import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConnexionDTO } from 'src/app/DTO/ConnexionDTO';
import { AuthService } from 'src/app/Service/AuthService';
import { Compte } from '../../../compte-feature/Compte/compte.model';
import { CompteService } from '../../../compte-feature/Compte/compte.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  creationIsOpen: boolean = false;
  
  public constructor(private router : Router, private compteService: CompteService, private authService : AuthService){}

  redirectToHome(){
    this.router.navigate(['/']);
  }
  
  onClick(click: boolean){
    this.creationIsOpen = click;
  }

  recupCompte(compte: Compte){
    this.creationIsOpen = !this.creationIsOpen;
    this.compteService.create(compte).subscribe();
  }
  
  connexion(connexionDTO: ConnexionDTO){
    console.log(connexionDTO);
    this.authService.connect(connexionDTO).subscribe();
  }
}

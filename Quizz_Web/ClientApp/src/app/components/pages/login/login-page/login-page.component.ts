import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from 'src/app/compte-feature/Compte/compte.model';
import { CompteService } from 'src/app/compte-feature/Compte/compte.service';
import { ConnexionDTO } from 'src/app/DTO/ConnexionDTO';
import { Globals } from 'src/app/globals';
import { AuthService } from 'src/app/Service/AuthService';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})

export class LoginPageComponent{

  creationIsOpen: boolean = false;
  
  public constructor(private router : Router, private compteService: CompteService, private authService : AuthService){}

  ngOnInit(){
    if(Globals.isLoggedOut()){
      Globals.initJwt('');
    }
  }
  
  redirectToLogin(){
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
    this.authService.connect(connexionDTO).subscribe(
      jwt => {
        Globals.initJwt(jwt);
      }
    );
  }
  
  logout(){
    Globals.logout();
  }

}

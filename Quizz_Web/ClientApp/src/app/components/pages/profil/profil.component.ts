import { Component, OnInit } from '@angular/core';
import { ComptePersonnelDTO } from 'src/app/DTO/ComptePersonnelDTO';
import { PermissionDTO } from 'src/app/DTO/PermissionDTO';
import { Globals } from 'src/app/globals';
import { BooleanPipe } from 'src/app/Pipe/boolean-pipe';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css'],
  providers: [BooleanPipe]
})
export class ProfilComponent implements OnInit {

  private comptePerso : ComptePersonnelDTO;

  constructor(private booleanPipe: BooleanPipe) { }

  ngOnInit(): void {
    if(Globals.isLoggedIn){
      let jwt = Globals.decodeJwt();

      if(this.checkJWTProps(jwt)){
        let permissionDTO = new PermissionDTO(jwt['GenererQuizz'], jwt['AjouterQuest'], jwt['ModifierQuest'], jwt['ModifierCompte'], jwt['SupprQuestion'], jwt['SupprimerCompte']);
        this.comptePerso = new ComptePersonnelDTO(jwt['nom'], jwt['prenom'], permissionDTO);
      }
    }
  }

  private checkJWTProps(jwt : string){
    return jwt['nom'] != null && jwt['prenom'] != null && 
    jwt['GenererQuizz'] != null && jwt['AjouterQuest'] != null &&
    jwt['ModifierQuest'] != null && jwt['SupprQuestion'] != null && 
    jwt['ModifierCompte'] != null && jwt['SupprimerCompte'] != null;
  }
}
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionNameDTO } from 'src/app/DTO/permissionNameDTO';
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
  newPerm: PermissionNameDTO;
  
  constructor(private compteService: CompteService, private router: Router) {
  }

  ngOnInit(): void {
  }

  startModify(): void{
    this.modifying = !this.modifying;
  }

  supprimerCompte(): void{
    this.compteService.delete(this.compte).subscribe(response => {
      console.log('Le compte ' + this.compte.nom + ' a été supprimé.');
      this.refreshEvent.emit();
    });;
  }

  validateModifyPermission(): void{
    this.compteService.modifyPermission(this.compte, this.newPerm).subscribe(
      () => {
        this.modifying = false;
        this.refreshComponent();
      }
    );
  }

  permissionSelect(permissionNameDTO: PermissionNameDTO): void{
    this.newPerm = permissionNameDTO;
  }

  refreshComponent(): void{
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    }); 
  }

}

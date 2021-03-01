import { Component, OnInit } from '@angular/core';
import { Globals } from 'src/app/globals';
import { PermissionService } from 'src/app/Service/PermissionService';

@Component({
  selector: 'app-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.css']
})
export class PermissionComponent implements OnInit {

  AjouterQuest: boolean = false;
  GenererQuizz: boolean = false;
  ModifierCompte: boolean = false;
  ModifierQuest: boolean = false;
  SupprQuestion: boolean = false;
  SupprimerCompte: boolean = false;

  constructor(private permissionService : PermissionService) { }

  ngOnInit() {
    this.AjouterQuest = this.permissionService.verifyPermission('AjouterQuest');
    this.GenererQuizz = this.permissionService.verifyPermission('GenererQuizz');
    this.ModifierCompte = this.permissionService.verifyPermission('ModifierCompte');
    this.ModifierQuest = this.permissionService.verifyPermission('ModifierQuest');
    this.SupprQuestion = this.permissionService.verifyPermission('SupprQuestion');
    this.SupprimerCompte = this.permissionService.verifyPermission('SupprimerCompte');
  }

  canModifyOrSupprCompte(): boolean{
    return this.SupprimerCompte || this.ModifierCompte;
  }

}

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PermissionService } from '../../../Service/PermissionService';
import { PermissionNameDTO } from '../../../DTO/permissionNameDTO';
import { Compte } from '../../../compte-feature/Compte/compte.model';

@Component({
  selector: 'app-select-permission',
  templateUrl: './select-permission.component.html',
  styleUrls: ['./select-permission.component.css']
})
export class SelectPermissionComponent implements OnInit {

  permissionsNames: PermissionNameDTO[] = [];
  selectedPerm : PermissionNameDTO;
  @Input() compte : Compte;
  @Output() choixEvent = new EventEmitter<PermissionNameDTO>();

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
    this.permissionService.getAll().subscribe(response => {
      this.permissionsNames = response;
    });
  }

  changePermission(newPerm){
    this.selectedPerm = newPerm;
    this.choixEvent.emit(this.selectedPerm);
  }

}

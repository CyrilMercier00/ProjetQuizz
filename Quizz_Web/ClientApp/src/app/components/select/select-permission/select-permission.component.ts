import { Component, OnInit } from '@angular/core';
import { PermissionService } from '../../../Service/PermissionService';

@Component({
  selector: 'app-select-permission',
  templateUrl: './select-permission.component.html',
  styleUrls: ['./select-permission.component.css']
})
export class SelectPermissionComponent implements OnInit {

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
  }

  getAllPermissions(){
    this.permissionService
  }

}

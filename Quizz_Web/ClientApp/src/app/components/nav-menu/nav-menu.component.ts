import { Component } from '@angular/core';
import { PermissionService } from 'src/app/Service/PermissionService';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private permissionService: PermissionService) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  hasAccessTo(permission: string): boolean{
    return this.permissionService.verifyPermission(permission);
  }
}

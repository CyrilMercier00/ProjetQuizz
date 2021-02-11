import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComptesComponent } from './comptes/comptes.component';
import { CompteComponent } from './compte/compte.component';
import { CompteRoutingModule } from './compte-routing.module';

@NgModule({
  declarations: [
    ComptesComponent,
    CompteComponent,
  ],
  imports: [
    CommonModule,
    CompteRoutingModule
  ],
  exports: [
  ]
})
export class CompteFeatureModule { }

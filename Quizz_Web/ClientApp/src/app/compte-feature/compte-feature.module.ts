import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComptesComponent } from './comptes/comptes.component';
import { CompteComponent } from './compte/compte.component';
import { CompteRoutingModule } from './compte-routing.molule';
import { InputComponent } from './input/input.component';
import { BoutonValidationComponent } from './bouton-validation/bouton-validation.component';

@NgModule({
  declarations: [
    ComptesComponent,
    CompteComponent,
    InputComponent,
    BoutonValidationComponent
  ],
  imports: [
    CommonModule,
    CompteRoutingModule
  ],
  exports: [
  ]
})
export class CompteFeatureModule { }

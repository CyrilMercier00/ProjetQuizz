import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoutonValidationComponent } from './bouton-validation/bouton-validation.component';
import { InputComponent } from './input/input.component';



@NgModule({
  declarations: [
    BoutonValidationComponent,
    InputComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    BoutonValidationComponent,
    InputComponent
  ]
})
export class GeneraleModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ConnexionComponent } from './connexion/connexion.component';
import { GeneraleModule } from '../generale/generale.module';
import { ComptesComponent } from './comptes/comptes.component';
import { CompteComponent } from './compte/compte.component';

@NgModule({
  declarations: [
    ConnexionComponent,
    ComptesComponent,
    CompteComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      { path: 'login', component: ConnexionComponent },
      { path: 'comptes', component: ComptesComponent }
    ]),
    GeneraleModule
  ],
  exports: [
  ]
})
export class CompteFeatureModule { }

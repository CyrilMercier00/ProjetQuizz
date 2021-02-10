import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { QuizzQuestionComponent } from './quizz-question/quizz-question.component';
import { GenQuizzComponent } from './gen-quizz/gen-quizz.component';
import { AssignationQuizzComponent } from './assignation-quizz/assignation-quizz.component';
import { GestionQuizzComponent } from './gestion-quizz/gestion-quizz.component';
import { ConnexionComponent } from './connexion/connexion.component';
import { InputComponent } from './input/input.component';
import { BoutonValidationComponent } from './bouton-validation/bouton-validation.component';
import { ResultatsComponent } from './resultats/resultats.component';
import { PermissionComponent } from './permission/permission.component';
import { ChronometreComponent } from './chronometre/chronometre.component';

@NgModule({
  declarations: [
    QuizzQuestionComponent,
    AppComponent,
    NavMenuComponent,
    GenQuizzComponent,
    AssignationQuizzComponent,
    GestionQuizzComponent,
    ConnexionComponent,
    InputComponent,
    BoutonValidationComponent,
    ResultatsComponent,
    PermissionComponent,
    ChronometreComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'quizz-question', component: QuizzQuestionComponent },      // Page pour repondre aux questons
      { path: 'gen-quizz', component: GenQuizzComponent },                // Page pour créer un quizz
      { path: 'gest-quizz', component: GestionQuizzComponent },           // Page pour modifier un quizz
      { path: 'assign-quizz', component: AssignationQuizzComponent },     // Page pour assigner un quizz une fois crée
      { path: 'login', component: ConnexionComponent },                   // Page de connexion
      { path: 'resultats', component: ResultatsComponent },               // Page de fin de quizz
      { path: 'permission', component: PermissionComponent },             // Page de
      { path: 'chronometre', component: ChronometreComponent }            // Page de


    ])
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { QuizzQuestionComponent } from './quizz-question/quizz-question.component';
import { GenQuizzComponent } from './gen-quizz/gen-quizz.component';
import { AssignationQuizzComponent } from './assignation-quizz/assignation-quizz.component';
import { GestionQuizzComponent } from './gestion-quizz/gestion-quizz.component';
import { ResultatsComponent } from './resultats/resultats.component';
import { PermissionComponent } from './permission/permission.component';
import { ChronometreComponent } from './chronometre/chronometre.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CompteRoutingModule } from './compte-feature/compte-routing.module';
import { CompteFeatureModule } from './compte-feature/compte-feature.module';
import { FormulaireConnexionComponent } from './components/formulaire-connexion/formulaire-connexion.component';

@NgModule({
  declarations: [
    QuizzQuestionComponent,
    AppComponent,
    NavMenuComponent,
    GenQuizzComponent,
    AssignationQuizzComponent,
    GestionQuizzComponent,
    ResultatsComponent,
    PermissionComponent,
    ChronometreComponent,
    PageNotFoundComponent,
    HomeComponent,
    FormulaireConnexionComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CompteRoutingModule,
    CompteFeatureModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },                             // Page d'accueil
      { path: 'assign-quizz', component: AssignationQuizzComponent },     // Page pour assigner un quizz une fois crée
      { path: 'chronometre', component: ChronometreComponent },           //
      { path: 'gen-quizz', component: GenQuizzComponent },                // Page pour créer un quizz
      { path: 'gest-quizz', component: GestionQuizzComponent },           // Page pour modifier un quizz
      { path: 'quizz-question', component: QuizzQuestionComponent },      // Page pour repondre aux questons
      { path: 'permission', component: PermissionComponent },             //
      { path: 'resultats', component: ResultatsComponent },               // Page de fin de quizz
      { path: '**', component: PageNotFoundComponent },                   // Wildcard route for a 404 page
    ]),
  ],
  exports: [
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule { }

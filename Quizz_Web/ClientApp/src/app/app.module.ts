import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { QuizzQuestionComponent } from './components/quizz-question/quizz-question.component';
import { GenQuizzComponent } from './components/gen-quizz/gen-quizz.component';
import { AssignationQuizzComponent } from './components/assignation-quizz/assignation-quizz.component';
import { GestionQuizzComponent } from './components/gestion-quizz/gestion-quizz.component';
import { ResultatsComponent } from './resultats/resultats.component';
import { PermissionComponent } from './permission/permission.component';
import { ChronometreComponent } from './chronometre/chronometre.component';
import { FooterComponent } from './footer/footer.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FormulaireConnexionComponent } from './components/formulaire-connexion/formulaire-connexion.component';
import { SelectThemeComponent } from './components/select/select-theme/select-theme.component';
import { SelectNiveauComponent } from './components/select/select-niveau/select-niveau.component';
import { ComptesComponent } from './compte-feature/comptes/comptes.component';
import { CompteComponent } from './compte-feature/compte/compte.component';
import { InputNumberComponent } from './components/input/input-number/input-number.component';
import { ButtonValidComponent } from './components/buttons/button-valid/button-valid.component';
import { SelectCompteCandidatComponent } from './components/select/select-compte-candidat/select-compte-candidat.component';
import { FormulaireCreationCompteComponent } from './components/formulaire-creation-compte/formulaire-creation-compte.component';

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
    FooterComponent,
    PageNotFoundComponent,
    HomeComponent,
    CompteComponent,
    ComptesComponent,
    FormulaireConnexionComponent,
    SelectThemeComponent,
    SelectNiveauComponent,
    InputNumberComponent,
    ButtonValidComponent,
    SelectCompteCandidatComponent,
    FormulaireCreationCompteComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },                             // Page d'accueil
      { path: 'assign-quizz', component: AssignationQuizzComponent },     // Page pour assigner un quizz une fois crée
      { path: 'chronometre', component: ChronometreComponent },           //
      { path: 'gen-quizz', component: GenQuizzComponent },                // Page pour créer un quizz
      { path: 'gest-quizz', component: GestionQuizzComponent },           // Page pour modifier un quizz
      { path: 'quizz-question', component: QuizzQuestionComponent },      // Page pour repondre aux questons
      { path: 'permission', component: PermissionComponent },             //
      { path: 'resultats', component: ResultatsComponent },               // Page de fin de quizz
      { path: 'permission', component: PermissionComponent },             // Page de permission admin pour Joris
      { path: 'comptes', component: ComptesComponent },
      { path: '**', component: PageNotFoundComponent }                   // Wildcard route for a 404 page
    ]),

     
  ],
  exports: [
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule { }

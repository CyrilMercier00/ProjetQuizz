import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { QuizzQuestionComponent } from './components/pages/quizz-question/quizz-question.component';
import { GenQuizzComponent } from './components/pages/gen-quizz/gen-quizz.component';
import { AssignationQuizzComponent } from './components/pages/assignation-quizz/assignation-quizz.component';
import { GestionQuizzComponent } from './components/pages/gestion-quizz/gestion-quizz.component';
import { ResultatsComponent } from './components/pages/resultats/resultats.component';
import { PermissionComponent } from './components/pages/permission/permission.component';
import { ChronometreComponent } from './components/chronometre/chronometre.component';
import { FooterComponent } from './components/footer/footer.component';
import { PageNotFoundComponent } from './components/pages/page-not-found/page-not-found.component';
import { FormulaireConnexionComponent } from './components/formulaire/formulaire-connexion/formulaire-connexion.component';
import { SelectThemeComponent } from './components/select/select-theme/select-theme.component';
import { SelectNiveauComponent } from './components/select/select-niveau/select-niveau.component';
import { ComptesComponent } from './compte-feature/comptes/comptes.component';
import { CompteComponent } from './compte-feature/Compte/compte.component';
import { InputNumberComponent } from './components/input/input-number/input-number.component';
import { ButtonValidComponent } from './components/buttons/button-valid/button-valid.component';
import { SelectCompteCandidatComponent } from './components/select/select-compte-candidat/select-compte-candidat.component';
import { GenerateNiveauComponent } from './components/pages/generate-niveau/generate-niveau.component';
import { FormulaireCreationCompteComponent } from './components/formulaire/formulaire-creation-compte/formulaire-creation-compte.component';
import { ButtonAjouterNouveauCandidatComponent } from './components/buttons/button-ajouter-nouveau-candidat/button-ajouter-nouveau-candidat.component';
import { FormulaireCreationCandidatComponent } from './components/formulaire/formulaire-creation-candidat/formulaire-creation-candidat.component';
import { FormulaireAjoutQuestionBddComponent } from './components/formulaire/formulaire-creation-question/formulaire-creation-question.component';
import { DragabbleTextInputComponent } from './components/input/dragabble-text-input/dragabble-text-input.component';
import { PageCreationQuestionComponent } from './components/pages/page-creation-question/page-creation-question.component';
import { PageReponseLibreComponent } from './components/pages/page-reponse-libre/page-reponse-libre.component';
import { PageReponseQcmComponent } from './components/pages/page-reponse-qcm/page-reponse-qcm.component';
import { BoutonReponseQcmComponent } from './components/buttons/bouton-reponse-qcm/bouton-reponse-qcm.component';
import { EnonceComponent } from './components/text/enonce/enonce.component';
import { PageDebutQuizzComponent } from './components/pages/page-debut-quizz/page-debut-quizz.component';
import { CheckBoxComponent } from './components/input/check-box/check-box.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SelectPermissionComponent } from './components/select/select-permission/select-permission.component';
import { LoginPageComponent } from './components/pages/login/login-page/login-page.component';

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
    CompteComponent,
    ComptesComponent,
    FormulaireConnexionComponent,
    SelectThemeComponent,
    SelectNiveauComponent,
    InputNumberComponent,
    ButtonValidComponent,
    SelectCompteCandidatComponent,
    GenerateNiveauComponent,
    FormulaireCreationCompteComponent,
    ButtonAjouterNouveauCandidatComponent,
    FormulaireCreationCandidatComponent,
    FormulaireAjoutQuestionBddComponent,
    DragabbleTextInputComponent,
    PageCreationQuestionComponent,
    PageReponseLibreComponent,
    PageReponseQcmComponent,
    BoutonReponseQcmComponent,
    EnonceComponent,
    PageDebutQuizzComponent,
    SelectPermissionComponent,
    CheckBoxComponent,
    LoginPageComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo:'/login', pathMatch:'full' },                                                     // Page d'accueil
      { path: 'login', component: LoginPageComponent },
      { path: 'assignation-quizz', component: AssignationQuizzComponent },        // Page pour assigner un quizz une fois crée
      { path: 'chronometre', component: ChronometreComponent },             
      { path: 'creer-quizz', component: GenQuizzComponent },                              // Page pour créer un quizz
      { path: 'creer-niveau', component: GenerateNiveauComponent },                 // Page pour creer un nouveau niveau
      { path: 'gestion-quizz', component: GestionQuizzComponent },                   // Page pour modifier un quizz
      { path: 'quizz-question', component: QuizzQuestionComponent },              // Page pour repondre aux questons
      { path: 'permission', component: PermissionComponent },                  
      { path: 'resultats', component: ResultatsComponent },                                 // Page de fin de quizz
      { path: 'permission', component: PermissionComponent },                           // Page de permission admin pour Joris
      { path: 'comptes', component: ComptesComponent },
      { path: 'creation-question', component: PageCreationQuestionComponent },     // Page de creation des questions
      { path: 'reponse-qcm', component: PageReponseQcmComponent },                   // Page de réponse pour les questions qcm
      { path: 'reponse-libre', component: PageReponseLibreComponent },                  // Page de réponse pour les questions libres
      { path: 'page-demarrage/:urlQuizz', component: PageDebutQuizzComponent}, // Page de demarrage du quizz
      { path: '**', component: PageNotFoundComponent }                                          // Wildcard route for a 404 page
    ]),


  ],
  exports: [
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

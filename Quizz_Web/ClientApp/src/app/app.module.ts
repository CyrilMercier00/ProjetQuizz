import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AssignationQuizzComponent } from './components/pages/assignation-quizz/assignation-quizz.component';
import { BoutonReponseQcmComponent } from './components/buttons/bouton-reponse-qcm/bouton-reponse-qcm.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonAjouterNouveauCandidatComponent } from './components/buttons/button-ajouter-nouveau-candidat/button-ajouter-nouveau-candidat.component';
import { ButtonValidComponent } from './components/buttons/button-valid/button-valid.component';
import { CheckBoxComponent } from './components/input/check-box/check-box.component';
import { ChronoComponent } from './components/chrono/chrono.component';
import { CompteComponent } from './compte-feature/Compte/compte.component';
import { ComptesComponent } from './compte-feature/comptes/comptes.component';
import { DragabbleTextInputComponent } from './components/input/dragabble-text-input/dragabble-text-input.component';
import { EnonceComponent } from './components/text/enonce/enonce.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormulaireAjoutQuestionBddComponent } from './components/formulaire/formulaire-creation-question/formulaire-creation-question.component';
import { FormulaireConnexionComponent } from './components/formulaire/formulaire-connexion/formulaire-connexion.component';
import { FormulaireCreationCandidatComponent } from './components/formulaire/formulaire-creation-candidat/formulaire-creation-candidat.component';
import { FormulaireCreationCompteComponent } from './components/formulaire/formulaire-creation-compte/formulaire-creation-compte.component';
import { FormulaireCreationNiveauComponent } from './components/formulaire/formulaire-creation-niveau/formulaire-creation-niveau.component';
import { GenQuizzComponent } from './components/pages/gen-quizz/gen-quizz.component';
import { GenerateNiveauComponent } from './components/pages/generate-niveau/generate-niveau.component';
import { GenererQuizzGuard } from './Guards/GenererQuizzGuard';
import { GestionQuizzComponent } from './components/pages/gestion-quizz/gestion-quizz.component';
import {HttpClientModule} from '@angular/common/http';
import { InputNumberComponent } from './components/input/input-number/input-number.component';
import { LoginPageComponent } from './components/pages/login/login-page/login-page.component';
import { ModifierCompteGuard } from './Guards/ModifierCompteGuard';
import { ModifierQuestGuard } from './Guards/ModifierQuestGuard';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { PageCreationQuestionComponent } from './components/pages/page-creation-question/page-creation-question.component';
import { PageDebutQuizzComponent } from './components/pages/page-debut-quizz/page-debut-quizz.component';
import { PageNotFoundComponent } from './components/pages/page-not-found/page-not-found.component';
import { PageReponseLibreComponent } from './components/pages/page-reponse-libre/page-reponse-libre.component';
import { PageReponseQcmComponent } from './components/pages/page-reponse-qcm/page-reponse-qcm.component';
import { PermissionComponent } from './components/pages/permission/permission.component';
import { QuizzQuestionComponent } from './components/pages/quizz-question/quizz-question.component';
import { ResultatsComponent } from './components/pages/resultats/resultats.component';
import { RouterModule } from '@angular/router';
import { SelectCompteCandidatComponent } from './components/select/select-compte-candidat/select-compte-candidat.component';
import { SelectNiveauComponent } from './components/select/select-niveau/select-niveau.component';
import { SelectPermissionComponent } from './components/select/select-permission/select-permission.component';
import { SelectThemeComponent } from './components/select/select-theme/select-theme.component';
import { ProfilComponent } from './components/pages/profil/profil.component';
import { ConnexionGuard } from './Guards/ConnexionGuard';
import { BooleanPipe } from './Pipe/boolean-pipe';

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
    ChronoComponent,
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
    CheckBoxComponent,
    SelectPermissionComponent,
    FormulaireCreationNiveauComponent,
    CheckBoxComponent,
    LoginPageComponent,
    ProfilComponent,
    BooleanPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/login',
        pathMatch: 'full'
      },
      { // Page d'acceuil
        path: 'login',
        component: LoginPageComponent
      },
      { // Page pour assigner un quizz une fois crée
        path: 'assignation-quizz',
        component: AssignationQuizzComponent,
        canActivate: [GenererQuizzGuard]
      },
      {
        path: 'chronometre',
        component: ChronoComponent
      },
      { // Page pour créer un quizz
        path: 'creer-quizz',
        component: GenQuizzComponent,
        canActivate: [GenererQuizzGuard]
      },
      {  // Page pour creer un nouveau niveau
        path: 'creer-niveau',
        component: GenerateNiveauComponent,
        canActivate: [GenererQuizzGuard]
      },
      { // Page pour modifier un quizz
        path: 'gestion-quizz',
        component: GestionQuizzComponent,
        canActivate: [GenererQuizzGuard]
      },
      { // Page pour repondre aux questons
        path: 'quizz-question',
        component: QuizzQuestionComponent,
        canActivate: [ModifierQuestGuard]
      },
      {
        path: 'permission',
        component: PermissionComponent,
        canActivate: [ModifierCompteGuard]
      },
      { // Page de fin de quizz
        path: 'resultats',
        component: ResultatsComponent
      },
      {
        path: 'comptes',
        component: ComptesComponent,
        canActivate: [ModifierCompteGuard]
      },
      { // Page de creation des questions
        path: 'creation-question',
        component: PageCreationQuestionComponent,
        canActivate: [GenererQuizzGuard]
      },
      { // Page de réponse pour les questions qcm
        path: 'reponse-qcm',
        component: PageReponseQcmComponent
      },
      { // Page de réponse pour les questions libres
        path: 'reponse-libre',
        component: PageReponseLibreComponent
      },
      { // Page de demarrage du quizz
        path: 'page-demarrage/:urlQuizz',
        component: PageDebutQuizzComponent
      },
      { // Page de profil pour l'utilisateur
        path: 'profil',
        component: ProfilComponent,
        canActivate: [ConnexionGuard]
      },
      { // Wildcard route for a 404 page
        path: '**',
        component: PageNotFoundComponent
      }
    ]),


  ],
  exports: [
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

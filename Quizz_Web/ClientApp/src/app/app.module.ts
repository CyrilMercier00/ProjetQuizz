import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { QuizzQuestionComponent } from './quizz-question/quizz-question.component';
import { GenQuizzComponent } from './gen-quizz/gen-quizz.component';
import { GestQuizzComponent } from './gest-quizz/gest-quizz.component';
import { AssignationQuizzComponent } from './assignation-quizz/assignation-quizz.component';
import { GestionQuizzComponent } from './gestion-quizz/gestion-quizz.component';
import { ResultatsComponent } from './resultats/resultats.component';
import { PermissionComponent } from './permission/permission.component';
import { ChronometreComponent } from './chronometre/chronometre.component';

@NgModule({
  declarations: [
    QuizzQuestionComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    GenQuizzComponent,
    GestQuizzComponent,
    AssignationQuizzComponent,
    GestionQuizzComponent,
    ResultatsComponent,
    PermissionComponent,
    ChronometreComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'quizz-question', component: QuizzQuestionComponent },
      { path: 'gen-quizz', component: GenQuizzComponent },
      { path: 'gest-quizz', component: GestQuizzComponent },
      { path: 'resultats', component: ResultatsComponent },
      { path: 'permission', component: PermissionComponent },
      { path: 'chronometre', component: ChronometreComponent }
     
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

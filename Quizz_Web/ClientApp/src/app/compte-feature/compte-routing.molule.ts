import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ComptesComponent } from "./comptes/comptes.component";
import { ConnexionComponent } from "./connexion/connexion.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'comptes', component: ComptesComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class CompteRoutingModule{}
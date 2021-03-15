import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { ReponseCandidatDTO } from '../../../DTO/ReponseCandidatDTO';
import { serviceRepCandidat } from 'src/app/Service/serviceRepCandidat';
import { utils } from 'src/app/utils';

@Component({
  selector: 'app-page-reponse-qcm',
  templateUrl: './page-reponse-qcm.component.html',
  styleUrls: ['./page-reponse-qcm.component.css', '../../../app.flex-util.css']
})



export class PageReponseQcmComponent implements OnInit
{



  /* ------ Declaration des variables ------ */
  @Input("dataQuestion") dataQ: DTOQuestion;                                             // DTO de la question passée
  @Output("estRepondu") estRepondu: EventEmitter<boolean> = new EventEmitter<boolean>() // Emmet si on appuie sur valider

  rep1: string;               // Texte de la réponse 1
  rep2: string;               // Texte de la réponse 2
  rep3: string;               // Texte de la réponse 3
  rep4: string;               // Texte de la réponse 4
  enonce: string;             // Enonce de la question
  textCommentaire: string;    // Commentaire du candidat


  /* ------ Constructeur ------ */
  constructor()
  {
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
    this.enonce == this.dataQ.$Enonce;

    // * Choisis les reponses aléatoirement
    // Génère un array de 4 nombre entre 0 et le nombre max de reponses disponibles pour cette question
    let arrayNbChoisis = utils.nbAleatUnique(4, 0, this.dataQ.$ListeReponses.length)

    // Utiliser ces nombres pour afficher le questions
    /*
    this.rep1 = this.dataQ.$ListeReponses[arrayNbChoisis[0]];
    this.rep2 = this.dataQ.$ListeReponses[arrayNbChoisis[1]];
    this.rep3 = this.dataQ.$ListeReponses[arrayNbChoisis[2]];
    this.rep4 = this.dataQ.$ListeReponses[arrayNbChoisis[3]];
    */
    this.rep1 = this.dataQ.$ListeReponses[0].Text;
    this.rep2 = this.dataQ.$ListeReponses[1].Text;
    this.rep3 = this.dataQ.$ListeReponses[2].Text;
    this.rep4 = this.dataQ.$ListeReponses[3].Text;

  }



  /* ------ Methodes ------*/
  GetClick(idRep)
  {
    console.log("cc")
    let dtoRep = new ReponseCandidatDTO()

    dtoRep.$Commentaire = this.textCommentaire;
    dtoRep.$Reponse = this.dataQ.$ListeReponses[idRep];
    dtoRep.$FKCompte = null;     // TODO : Get compte candidat qui passe
    dtoRep.$FKQuestion = this.dataQ.$PKQuestion;

    serviceRepCandidat.PostReponse(dtoRep)

    this.estRepondu.emit(true);

  }
}

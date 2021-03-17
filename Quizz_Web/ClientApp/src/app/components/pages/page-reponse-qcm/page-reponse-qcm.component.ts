import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { ReponseCandidatDTO } from '../../../DTO/ReponseCandidatDTO';
import { serviceRepCandidat } from 'src/app/Service/serviceRepCandidat';
import { utils } from 'src/app/utils';
import { Globals } from 'src/app/globals';

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
  clicked: boolean = false    // Pour empecher plusieurs envois

  /* ------ Constructeur ------ */
  constructor()
  {
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
    this.enonce == this.dataQ.$Enonce;

    this.rep1 = this.dataQ.$ListeReponses[0].Text;
    this.rep2 = this.dataQ.$ListeReponses[1].Text;
    this.rep3 = this.dataQ.$ListeReponses[2].Text;
    this.rep4 = this.dataQ.$ListeReponses[3].Text;

  }



  /* ------ Methodes ------*/
  GetClick(idRep)
  {
    if (this.clicked == false)
    {
      let dtoRep = new ReponseCandidatDTO()

    dtoRep.$Commentaire = this.textCommentaire;
    dtoRep.$Reponse = this.dataQ.$ListeReponses[idRep];
    dtoRep.$FKCompte = Globals.getId();
    dtoRep.$FKQuestion = this.dataQ.$PKQuestion;

      // Envoi de la reponse
      serviceRepCandidat.PostReponse(dtoRep).then(x =>
      {
        // Vider les champs
        this.rep1 = ""
        this.rep2 = ""
        this.rep3 = ""
        this.rep4 = ""
        this.textCommentaire = ""

        // Emit pour passer a la prochaine question
        this.estRepondu.emit(true)

      })
    }
  }



  onComentChange($event)
  {
    console.log("azdazs")
    console.log($event.target.value)
    this.textCommentaire = $event.target.value
  };

}

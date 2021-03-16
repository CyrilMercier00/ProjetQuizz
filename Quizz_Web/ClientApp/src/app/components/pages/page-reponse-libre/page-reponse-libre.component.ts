import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import { ReponseCandidatDTO } from 'src/app/DTO/ReponseCandidatDTO';
import { serviceRepCandidat } from 'src/app/Service/serviceRepCandidat';

@Component({
  selector: 'app-page-reponse-libre',
  templateUrl: './page-reponse-libre.component.html',
  styleUrls: ['./page-reponse-libre.component.css']
})



export class PageReponseLibreComponent implements OnInit
{

  /* ------ Declaration des variables ------ */
  @Input("dataQuestion") dataQ: DTOQuestion;                                             // DTO de la question passée
  @Output("estRepondu") estRepondu: EventEmitter<boolean> = new EventEmitter<boolean>()  // Emmet si on appuie sur valider

  enonce: string              // Enonce de la question
  textCommentaire: string     // Commentaire du candidat
  answer: string              // Réponse écrite
  resultatForm: FormGroup     // Resultat du formulaire
  clicked: boolean = false    // Pour empecher plusieurs envois

  /* ------ Constructeur ------ */
  constructor(private builder: FormBuilder)
  {
    this.resultatForm = this.builder.group
      ({
        textCommentaire: [''],
        answer: [''],
      })
  }



  /* ------ Methodes Angular --- */
  ngOnInit()
  {
    this.enonce = this.dataQ.$Enonce;
  }



  /* ------ Methodes ------*/
  // Envoi de la réponse a la base de données
  handleClick()
  {
    if (this.clicked == false)
    {
      this.clicked = true;
      let data = new ReponseCandidatDTO();

      data.$Commentaire = this.resultatForm.value.textCommentaire;
      data.$Reponse = this.resultatForm.value.answer;
      data.$FKCompte = null;                                        // TODO : Recuperer l'id du cadidat a partir du lien gen
      data.$FKQuestion = this.dataQ.$PKQuestion;

      serviceRepCandidat.PostReponse(data)
        .then(x => this.estRepondu.emit(true))
    }
  }



  onAnswerChange($event)
  {
    this.resultatForm.patchValue({ "textCommentaire": $event.target.value });
  }



  onComentChange($event)
  {
    this.resultatForm.patchValue({ "enonce": $event.target.value });
  }
}


import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { DTOQuestion } from 'src/app/DTO/questionDTO';
import jwtDecode from 'jwt-decode';
import { reponseDTO } from 'src/app/DTO/reponseDTO';

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
  handleClick ()
  {
    let data = new reponseDTO();

    data.$Commentaire = this.textCommentaire;
    data.$Reponse = this.answer;
    data.$FKCompte = null;                                        // TODO : Recuperer l'id du cadidat a partir du lien gen
    data.$FKQuestion = this.dataQ.$PKQuestion;

    this.estRepondu.emit(true);
   
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


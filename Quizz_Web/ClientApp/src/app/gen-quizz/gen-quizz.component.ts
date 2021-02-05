import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from '../globales';
import { Quizz } from "../DTO/quizzDTO"
import { JsonpClientBackend } from '@angular/common/http';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-gen-quizz',
  templateUrl: './gen-quizz.component.html',
  styleUrls: [ './gen-quizz.component.css', '../app.flex-util.css' ]
})
export class GenQuizzComponent implements OnInit
{

  urlGetTheme = VariableGlobales.apiURL + "theme";
  urlGetComplexite = VariableGlobales.apiURL + "niveau";
  urlPostQuizz = VariableGlobales.apiURL + "quizz"

  idCompte = this.getCompteID();    // ID du compte utilisateur
  inputNbQuestion = 0;              // Nombre de questions affiché dans l'input
  inputTheme = "c#";                //
  inputComplexite = "Débutant";     //
  quizz = new Quizz();              // Le DTO du quizz qui va etre envoyé a l'api
  valRetourRequeteTheme;            // Contiens le retour de la requete theme
  valRetourRequeteComplex;          // Contiens le retour de la requete complexite

  constructor()
  {
    console.log(this.urlGetComplexite);
    console.log(this.urlGetTheme);
    this.setValeursAFfichage();
  }

  ngOnInit()
  {
  }

  setValeursAFfichage()
  {

    try
    {

      // Insertion des valeurs dans les select
      this.valRetourRequeteTheme = this.getAllTheme();
      this.valRetourRequeteComplex = this.getAllComplexite();

      if (this.valRetourRequeteTheme != null)
      {
        {
          if (this.valRetourRequeteComplex != null)
          {



          } else
          {
            throw new Error('Probleme lors de la recuperation du niveau de complextité')
          }
        }

      } else
      {
        throw new Error('Probleme de de la recuperation des themes ')
      }

    } catch (e)
    {
      alert("Debug: " + e.message)
    }
  }

  // Retourne l'id du compte qui a créer le quizz
  getCompteID()
  {
    return 1;
  }

  /* --- Fonctions acces api --- */
  // Envoie le dto a l'api
  CreerQuizz()
  {
    console.log("Creer quizz");
  }
  // Retourne le json des themes disponibles
  getAllTheme()
  {
    let reponse = fetch(this.urlGetTheme, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        return json;
      });
  }
  // Retourne le json des complexites disponibles
  getAllComplexite()
  {
    let reponse = fetch(this.urlGetComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        return JSON.parse(json);
      });
  }

}

import { DTOQuestion } from "./questionDTO";
import { DTOQuizz } from "./dto-quizz";

export class utilDTO
{

  // * Transforme les données recues de la requete GET en array de DTO
  public static DTOTransformQuestion(prmDataQuestion: any): DTOQuestion[]
  {
    let arrayDTO: DTOQuestion[] = [];

    prmDataQuestion.forEach(question =>
    {
      let q = new DTOQuestion()

      q.$Enonce = question.Enonce
      q.$ListeReponses = question.ListeReponses
      q.$PKQuestion = question.PKQuestion
      q.$RepLibre = question.RepLibre
      q.$Theme = question.Theme
      q.$complexite = question.Complexite

      arrayDTO.push(q)
    });

    return arrayDTO
  }



  // * Transforme les données recues de la requete GET en DTO
  public static DTOTransformQuizz(prmDataQuizz: any): DTOQuizz
  {
    let dataQuizz = new DTOQuizz();

    dataQuizz.$Complexite = prmDataQuizz.complexite;
    dataQuizz.$Chrono = prmDataQuizz.chrono;
    dataQuizz.$FKCompteRecruteur = prmDataQuizz.fkCompteRecruteur;
    dataQuizz.$UrlCode = prmDataQuizz.urlcode;
    dataQuizz.$Theme = prmDataQuizz.theme;

    return dataQuizz;
  }

}

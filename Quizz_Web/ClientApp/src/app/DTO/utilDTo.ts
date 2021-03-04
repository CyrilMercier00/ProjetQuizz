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
      arrayDTO.push(question)
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

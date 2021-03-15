import { Globals } from "../globals";
import { VariableGlobales } from "../url_api";

export class ServiceQuestions
{

  // * Retourne la liste des questions du quizz avec l'id passé en param
  public static GetQuestionsByIDQuizz(prmPKQuizz: number): Promise<Response>
  {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    return fetch(VariableGlobales.apiURLQuestion + prmPKQuizz, { method: "GET", headers: requestHeaders })
  }

  public static GetQuestionsByCodeQuizz(prmCodeQuizz: string): Promise<Response>
  {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    console.log(VariableGlobales.apiURLQuestion + "AvecLesQuesitionsSVP/" + prmCodeQuizz, { method: "GET", headers: requestHeaders })
    return fetch(VariableGlobales.apiURLQuestion + "AvecLesQuesitionsSVP/" + prmCodeQuizz, { method: "GET", headers: requestHeaders })
  }

}

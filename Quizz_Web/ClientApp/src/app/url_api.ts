import { environment } from "src/environments/environment";

export class VariableGlobales
{
  public static apiURLCompte = + environment.urlBack + "api/compte/";
  public static apiURLComplexite = environment.urlBack + "api/complexite/";
  public static apiURLQuizz = environment.urlBack + "api/quizz/";
  public static apiURLQuestion = environment.urlBack + "api/question/";
  public static apiURLReponseCandidat = environment.urlBack + "api/reponsecandidat/";
  public static apiURLTheme = VariableGlobales + "api/theme/";
}

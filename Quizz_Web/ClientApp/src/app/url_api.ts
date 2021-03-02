export class VariableGlobales
{
  public static apiURL: string = window.location.origin + "/api/";    // Url d'origine (ex: https://localhost/api/)
  public static apiURLCompte = VariableGlobales.apiURL + "compte/";
  public static apiURLTheme = VariableGlobales.apiURL + "theme/";
  public static apiURLComplexite = VariableGlobales.apiURL + "complexite/";
  public static apiURLQuizz = VariableGlobales.apiURL + "quizz/";
  public static apiURLQuestion = VariableGlobales.apiURL + "question/";
  public static apiURLNiveau = VariableGlobales.apiURL + "complexite/";
  static apiURLReponseCandidat = VariableGlobales.apiURL + "reponsecandidat";
  static apiURLPermission = VariableGlobales.apiURL + "permission";
}

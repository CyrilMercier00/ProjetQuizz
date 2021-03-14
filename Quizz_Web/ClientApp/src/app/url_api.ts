export class VariableGlobales
{
  static apiURL: string = window.location.origin + "/api/";    // Url d'origine (ex: https://localhost/api/)
  static apiURLCompte = VariableGlobales.apiURL + "compte/";
  static apiURLLogin = VariableGlobales.apiURL + "login/";
  static apiURLTheme = VariableGlobales.apiURL + "theme/";
  static apiURLComplexite = VariableGlobales.apiURL + "complexite/";
  static apiURLQuizz = VariableGlobales.apiURL + "quizz/";
  static apiURLQuestion = VariableGlobales.apiURL + "question/";
  static apiURLReponseCandidat = VariableGlobales.apiURL + "reponsecandidat";
  static apiURLPermission = VariableGlobales.apiURL + "permission/";  
  static apiURLFinQuizz = VariableGlobales.apiURLQuizz+ "quizzsuccess/";
}

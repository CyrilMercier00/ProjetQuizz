export class ReponseCandidatDTO
{
  private Reponse: string;
  private Commentaire: string;
  private FKCompte: string;
  private FKQuestion: string;

  /**
   * Getter $Reponse
   * @return {string}
   */
  public get $Reponse(): string
  {
    return this.Reponse;
  }

  /**
   * Getter $Commentaire
   * @return {string}
   */
  public get $Commentaire(): string
  {
    return this.Commentaire;
  }

  /**
   * Getter $FKCompte
   * @return {string}
   */
  public get $FKCompte(): string
  {
    return this.FKCompte;
  }

  /**
   * Getter $FKQuestion
   * @return {string}
   */
  public get $FKQuestion(): string
  {
    return this.FKQuestion;
  }

  /**
   * Setter $Reponse
   * @param {string} value
   */
  public set $Reponse(value: string)
  {
    this.Reponse = value;
  }

  /**
   * Setter $Commentaire
   * @param {string} value
   */
  public set $Commentaire(value: string)
  {
    this.Commentaire = value;
  }

  /**
   * Setter $FKCompte
   * @param {string} value
   */
  public set $FKCompte(value: string)
  {
    this.FKCompte = value;
  }

  /**
   * Setter $FKQuestion
   * @param {string} value
   */
  public set $FKQuestion(value: string)
  {
    this.FKQuestion = value;
  }

}

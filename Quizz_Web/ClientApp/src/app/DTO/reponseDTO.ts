export class reponseDTO
{

  private Commentaire: string;
  private Reponse: string;
  private FKCompte: number;
  private FKQuestion: number;

  /**
   * Getter $Commentaire
   * @return {string}
   */
  public get $Commentaire(): string
  {
    return this.Commentaire;
  }

  /**
   * Getter $Reponse
   * @return {string}
   */
  public get $Reponse(): string
  {
    return this.Reponse;
  }

  /**
   * Getter $FKCompte
   * @return {number}
   */
  public get $FKCompte(): number
  {
    return this.FKCompte;
  }

  /**
   * Getter $FKQuestion
   * @return {number}
   */
  public get $FKQuestion(): number
  {
    return this.FKQuestion;
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
   * Setter $Reponse
   * @param {string} value
   */
  public set $Reponse(value: string)
  {
    this.Reponse = value;
  }

  /**
   * Setter $FKCompte
   * @param {number} value
   */
  public set $FKCompte(value: number)
  {
    this.FKCompte = value;
  }

  /**
   * Setter $FKQuestion
   * @param {number} value
   */
  public set $FKQuestion(value: number)
  {
    this.FKQuestion = value;
  }

}

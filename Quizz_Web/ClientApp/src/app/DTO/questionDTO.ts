export class DTOQuestion
{

  private PKQuestion: number;
  private Enonce: string;
  private RepLibre: boolean;
  private ListeReponses: any;
  private Theme: string;
  private complexite: string;

  /**
   * Getter $Theme
   * @return {string}
   */
  public get $Theme(): string
  {
    return this.Theme;
  }

  /**
   * Getter $complexite
   * @return {string}
   */
  public get $complexite(): string
  {
    return this.complexite;
  }

  /**
   * Setter $Theme
   * @param {string} value
   */
  public set $Theme(value: string)
  {
    this.Theme = value;
  }

  /**
   * Setter $complexite
   * @param {string} value
   */
  public set $complexite(value: string)
  {
    this.complexite = value;
  }


  /**
   * Getter $PKQuestion
   * @return {number}
   */
  public get $PKQuestion(): number
  {
    return this.PKQuestion;
  }

  /**
   * Getter $Enonce
   * @return {string}
   */
  public get $Enonce(): string
  {
    return this.Enonce;
  }

  /**
   * Getter $RepLibre
   * @return {boolean}
   */
  public get $RepLibre(): boolean
  {
    return this.RepLibre;
  }

  /**
   * Getter $ListeReponses
   * @return {any}
   */
  public get $ListeReponses(): any
  {
    return this.ListeReponses;
  }

  /**
   * Setter $PKQuestion
   * @param {number} value
   */
  public set $PKQuestion(value: number)
  {
    this.PKQuestion = value;
  }

  /**
   * Setter $Enonce
   * @param {string} value
   */
  public set $Enonce(value: string)
  {
    this.Enonce = value;
  }

  /**
   * Setter $RepLibre
   * @param {boolean} value
   */
  public set $RepLibre(value: boolean)
  {
    this.RepLibre = value;
  }

  /**
   * Setter $ListeReponses
   * @param {any} value
   */
  public set $ListeReponses(value: any)
  {
    this.ListeReponses = value;
  }



}

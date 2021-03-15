export class DTOQuizz
{

  private UrlCode: string;
  private FKCompteRecruteur: number;
  private NbQuestions: number;
  private Chrono: string;
  private Theme: string;
  private Complexite: string;

    /**
     * Getter $UrlCode
     * @return {string}
     */
	public get $UrlCode(): string {
		return this.UrlCode;
	}

    /**
     * Getter $FKCompteRecruteur
     * @return {number}
     */
	public get $FKCompteRecruteur(): number {
		return this.FKCompteRecruteur;
	}

    /**
     * Getter $NbQuestions
     * @return {number}
     */
	public get $NbQuestions(): number {
		return this.NbQuestions;
	}

    /**
     * Getter $Chrono
     * @return {string}
     */
	public get $Chrono(): string {
		return this.Chrono;
	}

    /**
     * Getter $Theme
     * @return {string}
     */
	public get $Theme(): string {
		return this.Theme;
	}

    /**
     * Getter $Complexite
     * @return {string}
     */
	public get $Complexite(): string {
		return this.Complexite;
	}

    /**
     * Setter $UrlCode
     * @param {string} value
     */
	public set $UrlCode(value: string) {
		this.UrlCode = value;
	}

    /**
     * Setter $FKCompteRecruteur
     * @param {number} value
     */
	public set $FKCompteRecruteur(value: number) {
		this.FKCompteRecruteur = value;
	}

    /**
     * Setter $NbQuestions
     * @param {number} value
     */
	public set $NbQuestions(value: number) {
		this.NbQuestions = value;
	}

    /**
     * Setter $Chrono
     * @param {string} value
     */
	public set $Chrono(value: string) {
		this.Chrono = value;
	}

    /**
     * Setter $Theme
     * @param {string} value
     */
	public set $Theme(value: string) {
		this.Theme = value;
	}

    /**
     * Setter $Complexite
     * @param {string} value
     */
	public set $Complexite(value: string) {
		this.Complexite = value;
	}

}

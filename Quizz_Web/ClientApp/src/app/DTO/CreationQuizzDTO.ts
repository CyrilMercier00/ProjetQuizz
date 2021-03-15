export class CreationQuizzDTO
{
  private FKCompteRecruteur: number;
  private NbQuestions: number;
  private Theme: string;
  private Complexite: string;

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

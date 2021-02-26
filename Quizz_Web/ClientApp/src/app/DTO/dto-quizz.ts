export class DTOQuizz
{
    private FKCompteRecruteur: number;
    private NbQuestions: number;
    private Chrono: string;
    private Theme: String;
    private Complexite: String;

    /**
     * Getter $FKCompteRecruteur
     * @return {number}
     */
    public get $FKCompteRecruteur(): number
    {
        return this.FKCompteRecruteur;
    }

    /**
     * Getter $NbQuestions
     * @return {number}
     */
    public get $NbQuestions(): number
    {
        return this.NbQuestions;
    }

    /**
     * Getter $Chrono
     * @return {string}
     */
    public get $Chrono(): string
    {
        return this.Chrono;
    }

    /**
     * Getter $Theme
     * @return {String}
     */
    public get $Theme(): String
    {
        return this.Theme;
    }

    /**
     * Getter Complexite
     * @return {String}
     */
    public get $Complexite(): String
    {
        return this.Complexite;
    }

    /**
     * Setter $FKCompteRecruteur
     * @param {number} value
     */
    public set $FKCompteRecruteur(value: number)
    {
        this.FKCompteRecruteur = value;
    }

    /**
     * Setter $NbQuestions
     * @param {number} value
     */
    public set $NbQuestions(value: number)
    {
        this.NbQuestions = value;
    }

    /**
     * Setter $Chrono
     * @param {string} value
     */
    public set $Chrono(value: string)
    {
        this.Chrono = value;
    }

    /**
     * Setter $Theme
     * @param {String} value
     */
    public set $Theme(value: String)
    {
        this.Theme = value;
    }

    /**
     * Setter Complexite
     * @param {String} value
     */
    public set $Complexite(value: String)
    {
        this.Complexite = value;
    }
}
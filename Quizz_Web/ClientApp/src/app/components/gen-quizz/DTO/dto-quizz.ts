export class DTOQuizz
{
    private _idCompteRecruteur: number;
    private _nbQuestions: number;
    private _theme: string;
    private _complexite: string;

    /**
     * Getter idCompteCandidat
     * @return {number}
     */
    public get idCompteCandidat(): number
    {
        return this._idCompteCandidat;
    }

    /**
     * Setter idCompteCandidat
     * @param {number} value
     */
    public set idCompteCandidat(value: number)
    {
        this._idCompteCandidat = value;
    }
    private _idCompteCandidat: number;


    /**
     * Getter idCompteRecruteur
     * @return {number}
     */
    public get idCompteRecruteur(): number
    {
        return this._idCompteRecruteur;
    }

    /**
     * Setter idCompteRecruteur
     * @param {number} value
     */
    public set idCompteRecruteur(value: number)
    {
        this._idCompteRecruteur = value;
    }



    /**
     * Getter theme
     * @return {string}
     */
    public get theme(): string
    {
        return this._theme;
    }

    /**
     * Setter theme
     * @param {string} value
     */
    public set theme(value: string)
    {
        this._theme = value;
    }

    /**
     * Getter complexite
     * @return {string}
     */
    public get complexite(): string
    {
        return this._complexite;
    }

    /**
     * Setter complexite
     * @param {string} value
     */
    public set complexite(value: string)
    {
        this._complexite = value;
    }
    /**
     * Getter nbQuestions
     * @return {number}
     */
    public get nbQuestions(): number
    {
        return this._nbQuestions;
    }

    /**
     * Setter nbQuestions
     * @param {number} value
     */
    public set nbQuestions(value: number)
    {
        this._nbQuestions = value;
    }


}
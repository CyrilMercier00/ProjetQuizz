export class questionDTO
{

    private Enonce: string;
    private RepLibre: boolean;
    private NomComplexite: number;
    private NomTheme: number;

    public get enonce(): string
    {
        return this.Enonce;
    }

    public set enonce(enonce: string)
    {
        this.Enonce = enonce;
    }

    public get repLibre(): boolean
    {
        return this.RepLibre;
    }

    public set repLibre(repLibre: boolean)
    {
        this.RepLibre = repLibre;
    }

    public get nomComplexite(): number
    {
        return this.NomComplexite;
    }

    public set nomComplexite(nomComplexite: number
    )
    {
        this.NomComplexite = nomComplexite;
    }

    public get nomTheme(): number
    {
        return this.NomTheme;
    }

    public set nomTheme(nomTheme: number)
    {
        this.NomTheme = nomTheme;
    }

















}
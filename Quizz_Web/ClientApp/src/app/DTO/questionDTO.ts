export class questionDTO
{

     private _enonce: string;
     private _repLibre : boolean;
     private _FKComplexite: number;
     private _FKTheme: number;

    public get enonce(): string
 {
        return this._enonce;
    }

    public set enonce(enonce: string
) {
        this._enonce = enonce;
    }

    public get repLibre(): boolean {
        return this._repLibre;
    }

    public set repLibre(repLibre: boolean) {
        this._repLibre = repLibre;
    }

    public get FKComplexite(): number
 {
        return this._FKComplexite;
    }

    public set FKComplexite(FKComplexite: number
) {
        this._FKComplexite = FKComplexite;
    }

    public get FKTheme(): number {
        return this._FKTheme;
    }

    public set FKTheme(FKTheme: number) {
        this._FKTheme = FKTheme;
    }














}
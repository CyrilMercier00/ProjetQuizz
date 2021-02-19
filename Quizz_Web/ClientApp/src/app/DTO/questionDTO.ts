export class questionDTO
{

     _text: string;
     _estBonne: boolean;
     _FKQuestion: number;
     _FKCompte: number;

    public get text(): string
    {
        return this._text;
    }

    public set text(text: string)
    {
        this._text = text;
    }

    public get estBonne(): boolean
    {
        return this._estBonne;
    }

    public set estBonne(estBonne: boolean)
    {
        this._estBonne = estBonne;
    }

    public get FKQuestion(): number
    {
        return this._FKQuestion;
    }

    public set FKQuestion(FKQuestion: number
    )
    {
        this._FKQuestion = FKQuestion;
    }

    public get FKCompte(): number
    {
        return this._FKCompte;
    }

    public set FKCompte(FKCompte: number)
    {
        this._FKCompte = FKCompte;
    }








}
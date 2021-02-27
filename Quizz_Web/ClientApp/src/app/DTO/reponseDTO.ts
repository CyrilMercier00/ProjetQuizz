export class reponseDTO {

     _Commentaire : string;
     _Reponse : string;
     _FKCompte: number;
     _FKQuestion:number;

    public get Commentaire(): string {
        return this._Commentaire;
    }

    public set Commentaire(Commentaire: string) {
        this._Commentaire = Commentaire;
    }

    public get Reponse(): string {
        return this._Reponse;
    }

    public set Reponse(Reponse: string) {
        this._Reponse = Reponse;
    }

    public get FKCompte(): number
 {
        return this._FKCompte;
    }

    public set FKCompte(FKCompte: number
) {
        this._FKCompte = FKCompte;
    }

    public get FKQuestion(): number {
        return this._FKQuestion;
    }

    public set FKQuestion(FKQuestion: number) {
        this._FKQuestion = FKQuestion;
    }



}
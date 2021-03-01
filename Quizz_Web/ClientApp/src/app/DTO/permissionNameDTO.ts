export class PermissionNameDTO {
    private PkPermission : number;
    private Nom : string;

    constructor(PkPermission: number, Nom: string, GenererQuizz: boolean, AjouterQuest: boolean, SupprQuestion: boolean,
        ModifierQuest: boolean, ModifierCompte: boolean, SupprimerCompte: boolean){

        this.PkPermission = PkPermission;
        this.Nom = Nom;
    }

    public GetPkPermission(): number{
        return this.PkPermission;
    }

    public GetNom(): string{
        return this.Nom;
    }
}

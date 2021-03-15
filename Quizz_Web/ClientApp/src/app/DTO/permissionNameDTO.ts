export class PermissionNameDTO {
    private PkPermission : number;
    private Nom : string;

    constructor(pkPermission: number, nom: string){

        this.PkPermission = pkPermission;
        this.Nom = nom;
    }

    public get GetPkPermission(): number{
        return this.PkPermission;
    }

    public get GetNom(): string{
        return this.Nom;
    }
}

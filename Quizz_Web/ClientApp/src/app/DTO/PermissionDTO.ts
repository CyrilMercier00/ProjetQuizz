export class PermissionDTO {
    private GenererQuizz    : boolean;
    private AjouterQuest    : boolean;
    private ModifierQuest   : boolean;
    private ModifierCompte  : boolean;
    private SupprQuestion   : boolean;
    private SupprimerCompte : boolean;

    constructor(GenererQuizz: boolean, AjouterQuest: boolean, ModifierQuest : boolean, ModifierCompte : boolean,
        SupprQuestion : boolean, SupprimerCompte : boolean){

        this.GenererQuizz       = GenererQuizz;
        this.AjouterQuest       = AjouterQuest;
        this.ModifierQuest      = ModifierQuest;
        this.ModifierCompte     = ModifierCompte;
        this.SupprQuestion      = SupprQuestion;
        this.SupprimerCompte    = SupprimerCompte;
    }

    public get GetGenererQuizz(): boolean{
        return this.GenererQuizz;
    }

    public get GetAjouterQuest(): boolean{
        return this.AjouterQuest;
    }
    
    public get GetModifierQuest(): boolean{
        return this.ModifierQuest;
    }
    
    public get GetModifierCompte(): boolean{
        return this.ModifierCompte;
    }

    public get GetSupprQuestion(): boolean{
        return this.SupprQuestion;
    }

    public get GetSupprimerCompte(): boolean{
        return this.SupprimerCompte;
    }
}

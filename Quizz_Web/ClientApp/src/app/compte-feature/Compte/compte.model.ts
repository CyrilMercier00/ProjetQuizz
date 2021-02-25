export class Compte {
    public id: number;
    public nom : string;
    private prenom : string;
    private mail : string;
    private mdp : string;
    public role : string;

    constructor(id: number, nom: string, prenom: string, mail: string, mdp: string, role: string){
        this.id = id;
        this.nom = nom;
        this.prenom = prenom;
        this.mail = mail;
        this.mdp = mdp;
        this.role = role;
    }
}

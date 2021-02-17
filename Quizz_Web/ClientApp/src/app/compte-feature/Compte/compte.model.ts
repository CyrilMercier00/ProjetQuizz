export class Compte {
    private id: number;
    private nom : string;
    private prenom : string;
    private mail : string;
    private mdp : string;
    private role : string;

    constructor(id: number, nom: string, prenom: string, mail: string, mdp: string, role: string){
        this.id = id;
        this.nom = nom;
        this.prenom = prenom;
        this.mail = mail;
        this.mdp = mdp;
        this.role = role;
    }
}

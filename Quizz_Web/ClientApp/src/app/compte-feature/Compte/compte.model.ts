export class Compte {
    private nom : string;
    private prenom : string;
    private mail : string;
    private mdp : string;
    private role : number;

    constructor(nom : string, prenom : string, mail : string, mdp : string, role : number){
        this.nom = nom;
        this.prenom = prenom;
        this.mail = mail;
        this.mdp = mdp;
        this.role = role;
    }
}

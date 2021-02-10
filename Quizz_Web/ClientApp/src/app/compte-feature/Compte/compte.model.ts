export class Compte {
    private _nom : string;
    private _prenom : string;
    private _mail : string;
    private _mdp : string;
    private _role : number;

    constructor(nom : string, prenom : string, mail : string, mdp : string, role : number){
        this._nom = nom;
        this._prenom = prenom;
        this._mail = mail;
        this._mdp = mdp;
        this._role = role;
    }
}

export class ConnexionDTO {
    private mail : string;
    private MotDePasse : string;

    constructor(mail: string, mdp: string){
        this.mail = mail;
        this.MotDePasse = mdp;
    }

    public get GetMail(): string{
        return this.mail;
    }

    public get GetMDP(): string{
        return this.MotDePasse;
    }

    public set SetMail(mail: string){
        this.mail = mail;
    }

    public set setMDP(mdp: string){
        this.MotDePasse = mdp;
    }
}
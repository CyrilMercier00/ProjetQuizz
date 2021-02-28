export class Globals
{
    static clientJwt: string;

    static logout(): void{
        this.clientJwt = "";
    }
}
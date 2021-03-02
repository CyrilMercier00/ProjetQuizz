import jwt_decode from "jwt-decode";

export class Globals
{
    static clientJwt: string = "";

    static logout(): void{
        this.clientJwt = "";
    }

    static isLoggedOut(): boolean{
        return this.clientJwt === "";
    }

    static decodeJwt(): string{
        let jwtdecode: string = jwt_decode(this.clientJwt);
        return jwtdecode; 
    }
}
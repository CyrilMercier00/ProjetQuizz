import jwt_decode from "jwt-decode";

export class Globals
{
  static initJwt(jwt: string): void
  {
    localStorage.setItem('clientJwt', jwt);
  }

  static getJwt(): string
  {
    return localStorage.getItem('clientJwt');
  }

  static logout(): void
  {
    localStorage.setItem('clientJwt', "");
  }

  static isLoggedIn(): boolean
  {
    return localStorage.getItem('clientJwt') != "";
  }

  static isLoggedOut(): boolean
  {
    return localStorage.getItem('clientJwt') == null || localStorage.getItem('clientJwt') == "";
  }

  static decodeJwt(): string
  {
    return jwt_decode(localStorage.getItem('clientJwt'));
  }

  static getId(): number{
    let decodedJwt: string;

    if(this.isLoggedIn()){
      decodedJwt = this.decodeJwt();
      return decodedJwt['id'];
    }

    return null;
  }
}

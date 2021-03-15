import { PermissionDTO } from "./PermissionDTO";

export class ComptePersonnelDTO
{
  private nom: string;
  private prenom: string;
  private permissionDTO: PermissionDTO;
  private PkQuizz: number;

  constructor(nom: string, prenom: string, permissionDTO: PermissionDTO)
  {

    this.nom = nom;
    this.prenom = prenom;
    this.permissionDTO = permissionDTO;
  }

  public get GetNom(): string
  {
    return this.nom;
  }

  public get GetPrenom(): string
  {
    return this.prenom;
  }

  public get GetPermissionDTO(): PermissionDTO
  {
    return this.permissionDTO;
  }


  /**
   * Getter $PkQuizz
   * @return {number}
   */
  public get $PkQuizz(): number
  {
    return this.PkQuizz;
  }

  /**
   * Setter $PkQuizz
   * @param {number} value
   */
  public set $PkQuizz(value: number)
  {
    this.PkQuizz = value;
  }
}

import { PermissionDTO } from "./PermissionDTO";

export class ComptePersonnelDTO
{
  private Mail : string;
  private nom: string;
  private prenom: string;
  private permissionDTO: PermissionDTO;
  private pk: number;

  /**
   * Getter $PkCompte
   * @return {number}
   */
  public get $PkCompte(): number
  {
    return this.pk;
  }

  /**
   * Setter $PkCompte
   * @param {number} value
   */
  public set $PkCompte(value: number)
  {
    this.pk = value;
  }

  
  /**
   * Getter $PkCompte
   * @return {number}
   */
   public get $Mail(): string
   {
     return this.Mail;
   }
 
   /**
    * Setter $PkCompte
    * @param {number} value
    */
   public set $Mail(value: string)
   {
     this.Mail = value;
   }

   
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

}

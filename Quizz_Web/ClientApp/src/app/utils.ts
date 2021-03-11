export class utils
{

  /**
  * Genere une liste de nombre uniques
  * @return {number array}
  */
  public static nbAleatUnique(prmQteAGen, prmNbMin, prmNbMax): number[]
  {

    let num;
    let arrayNumber = [];

    let uniqueNumber = (prmNbMax) =>
    {
      num = Math.floor((Math.random() * prmNbMax) + 1);

      if (!arrayNumber.includes(num)) // Si n'est pas deja pris
      {
        arrayNumber.push(num);
        return num;
      } else if (arrayNumber.length - 1 !== prmNbMax)
      {
        uniqueNumber(prmNbMax); // Reprendre u nautre nombre
      }
    }

    return arrayNumber;

  }

}

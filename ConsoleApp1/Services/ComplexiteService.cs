using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.Services
{
    public class ComplexiteService
    {
        private readonly ComplexiteRepository _complexiteRepository;

        public TauxComplexite AjouterTauxComplexite ( TauxComplexite taux_Complexite )
        {


            return this._complexiteRepository.Create(taux_Complexite);

        }

        public TauxComplexite ModifierVentilation (int id, TauxComplexite noveautxcomplexite) 
        {
            noveautxcomplexite.PkComplexite = id;
            return this._complexiteRepository.Update( id, noveautxcomplexite);
        }

        public List<Taux_complexiteDTO> GetComplexites ()
        {
            List<bdd_quizz.TauxComplexite> tauxComplexites = _complexiteRepository.GetAllComplexite ();
            List<Taux_complexiteDTO> ttlestauxDTO = new List<Taux_complexiteDTO> ();
            tauxComplexites.ForEach (taux => { ttlestauxDTO.Add (TransferModelToDto (taux)); });
            return ttlestauxDTO;
        }

        private Taux_complexiteDTO TransferModelToDto ( TauxComplexite taux )
        {
            return new Taux_complexiteDTO (taux.Niveau, taux.QuestionJunior, taux.QuestConfirme, taux.QuestionExperimente);
        }

        public Taux_complexiteDTO GetComplexite ( string nomcomplex )
        {
            bdd_quizz.TauxComplexite tauxComplexite = _complexiteRepository.GetComplexiteByNom (nomcomplex);
            return TransferModelToDto (tauxComplexite);
        }

    }
}
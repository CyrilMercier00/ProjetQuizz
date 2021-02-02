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

        public void AjouterTauxComplexite ( Taux_complexiteDTO taux_Complexite )
        {


        }

        public void ModifierVentilation () { }

        public List<Taux_complexiteDTO> GetListComplexites ()
        {
            List<TauxComplexite> tauxComplexites = _complexiteRepository.GetAllComplexite ();
            List<Taux_complexiteDTO> ttlestauxDTO = new List<Taux_complexiteDTO> ();
            tauxComplexites.ForEach (taux => { ttlestauxDTO.Add (TransferModelToDto (taux)); });
            return ttlestauxDTO;
        }

        private Taux_complexiteDTO TransferModelToDto ( TauxComplexite taux )
        {
            return new Taux_complexiteDTO ()
            {
                niveau = taux.Niveau,
                question_junior = taux.QuestionJunior,
                quest_confirme = taux.QuestConfirme,
                question_experimente = taux.QuestionExperimente
            };

        }
        public Taux_complexiteDTO GetComplexiteByNom ( string nomcomplex )
        {
            TauxComplexite tauxComplexite = _complexiteRepository.GetTauxComplexiteByNom (nomcomplex);
            return TransferModelToDto (tauxComplexite);
        }

    }
}
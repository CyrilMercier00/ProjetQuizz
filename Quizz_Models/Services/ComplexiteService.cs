﻿using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System.Collections.Generic;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class ComplexiteService
    {
        private readonly ComplexiteRepository _complexiteRepository;

        public ComplexiteService(ComplexiteRepository repoComplexite)
        {
            _complexiteRepository = repoComplexite;
        }

        public TauxComplexite AjouterTauxComplexite(TauxComplexite taux_Complexite)
        {


            return this._complexiteRepository.Create(taux_Complexite);

        }

        public void ModifierVentilation(int id, TauxComplexite noveautxcomplexite)
        {

            this._complexiteRepository.Update(id, noveautxcomplexite);
        }

        public List<Taux_complexiteDTO> GetComplexites()
        {
            List<bdd_quizz.TauxComplexite> tauxComplexites = new List<bdd_quizz.TauxComplexite>();
            tauxComplexites = _complexiteRepository.GetAllComplexite();
            List<Taux_complexiteDTO> ttlestauxDTO = new List<Taux_complexiteDTO>();
            tauxComplexites.ForEach(taux => { ttlestauxDTO.Add(TransferModelToDto(taux)); });
            return ttlestauxDTO;
        }

        private Taux_complexiteDTO TransferModelToDto(TauxComplexite taux)
        {
            return new Taux_complexiteDTO(taux.PkComplexite, taux.Niveau, taux.QuestionJunior, taux.QuestionConfirme, taux.QuestionExperimente);
        }

        public Taux_complexiteDTO GetComplexite(int id)
        {

            return TransferModelToDto(this._complexiteRepository.GetComplexiteByID(id));
        }

        public void Delete(int id)
        {
            this._complexiteRepository.Delete(id);
        }

    }
}
﻿using System;
using System.Linq;


namespace Quizz_Models.Services
{
    public class CompteRepository
    {
        private readonly bdd_quizzEntities bdd_entities = new bdd_quizzEntities ();
        public CompteRepository () { }

        public compte GetCompteByID ( int prmID )
        {
            return bdd_entities.compte.Find (prmID);
        }

        public void InsertCompte ( compte prmCompte )
        {
            bdd_entities.compte.Add (prmCompte);
        }

        public void DeleteCompte ( int compteID )
        {
            compte compteEntity = bdd_entities.compte.Find (compteID);
            bdd_entities.compte.Remove (compteEntity);
        }
    }
}

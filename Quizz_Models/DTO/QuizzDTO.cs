﻿using System;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        public int FKCompteRecruteur { get; set; }
        public int FKCompteAssigne { get; set; }
        public int NbQuestions { get; set; }
        public String Chrono { get; set; }
        public String Theme { get; set; }
        public String Complexite { get; set; }
        public String Urlcode { get; set; }

    }
}

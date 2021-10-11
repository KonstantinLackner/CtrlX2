using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Variation
    {
        public String sentence { get; }
        public int leadsToLevel { get; }
        public bool[] boolList { get; set; }

        public Variation(String sentence, int leadsToLevel, bool[] boolList)
        {
            this.sentence = sentence;
            this.leadsToLevel = leadsToLevel;
            this.boolList = boolList;
        }
    }
}
using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Variation
    {
        public String sentence { get; }
        public int leadsToLevel { get; }
        public bool[] boolList { get; set; }
        
        public String[] killSafe { get; set; }

        public Variation(String sentence, int leadsToLevel, bool[] boolList, String[] killSafe)
        {
            this.sentence = sentence;
            this.leadsToLevel = leadsToLevel;
            this.boolList = boolList;
            this.killSafe = killSafe;
        }
    }
}
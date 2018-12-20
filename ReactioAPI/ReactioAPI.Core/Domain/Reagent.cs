using System;
using System.Collections.Generic;
using System.Text;
namespace ReactioAPI.Core.Domain
{
    public class Reagent
    {
        public Reagent()
        {
        }

        public Reagent(string name,
            string pattern,
            string namePL)
        {
            Name = name;
            Pattern = pattern;
            NamePL = namePL;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public string NamePL { get; protected set; }

        public string Pattern { get; protected set; }
    }
}

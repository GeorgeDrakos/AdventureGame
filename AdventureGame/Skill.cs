using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    public class Skill
    {
        public Skill(string name, string details, string statScale)
        {
            Name = name;
            Details = details;
            StatScale = statScale;
            
        }

        public string Name { get; set; }
        public string Details { get; set; }
        public string StatScale { get; set; }

        public int DamageCalc (int scaleStat)
        {
            int damage = scaleStat - 5;
            return damage;
        }
    }
}

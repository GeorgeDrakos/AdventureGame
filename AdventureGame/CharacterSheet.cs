using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AdventureGame
{
    public class CharacterSheet
    {
        public CharacterSheet(string name, string race, string pcClass, string lb, int strength, int agility, int intelligence, int maxHP, int maxMP, int level, int curHP, int curMP)
        {
            Name = name;
            Race = race;
            PcClass = pcClass;
            Lb = lb;
            MaxHP = maxHP;
            MaxMP = maxMP;
            Level = level;
            CurHP = curHP;
            CurMP = curMP;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
        }

        public string Name { get; set; }
        public string Race { get; set; }
        public string PcClass { get; set; }
        public string Lb { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int Level { get; set; }
        public int CurMP { get; set; }
        public int CurHP { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Strength { get; set; }

        public string showDetails()
        {
            string detailsString = "Name: " + Name + "\nRace: " + Race + "\nClass: " + PcClass + "\nLevel: " + Level + "\nLB: " + Lb + "\nStrength: " + Strength + "\nAgility: " + Agility + "\nIntelligence: " + Intelligence
            + "\nHP: " + MaxHP + "\nMP: " + MaxMP;
            return detailsString;
        }

    }
}

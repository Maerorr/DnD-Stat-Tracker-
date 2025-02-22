using System.Collections.Generic;
using UnityEngine;

public class Spells
{
    public Dictionary<string, (Spell, bool)> cantrips;
    public List<Dictionary<string, (Spell, bool)>> spells;

    public Spells()
    {
        cantrips = new Dictionary<string, (Spell, bool)>();
        spells = new List<Dictionary<string, (Spell, bool)>>(9);
        for (int i = 0; i < 9; i++)
        {
            Dictionary<string, (Spell, bool)> d = new Dictionary<string, (Spell, bool)>();
            spells.Add(d);
        }
    }

    public void AddSpell(Spell spell, bool prepared)
    {
        if (spell.level == 0)
        {
            cantrips.Add(spell.name, (spell, true));
        }
        else
        {
            spells[spell.level - 1].Add(spell.name, (spell, prepared));
        }
    }

    public Dictionary<string, (Spell, bool)> GetSpellsOfLevel(int level)
    {
        if (level == 0)
        {
            return cantrips;
        }

        return spells[level - 1];
    }
    
    public List<(Spell, bool)> GetSpellsOfLevelAndClass(int level, Class c)
    {
        List<(Spell, bool)> list = new List<(Spell, bool)>();
        if (level == 0)
        {
            foreach (var spell in cantrips)
            {
                if (spell.Value.Item1.classes.Contains(c))
                {
                    list.Add(spell.Value);
                }
            }

            return list;
        }

        var spellsOfLevel = spells[level - 1];
        foreach (var spell in spellsOfLevel)
        {
            if (spell.Value.Item1.classes.Contains(c))
            {
                list.Add(spell.Value);
            }
        }

        return list;
    }

    public Spell GetSpellOfLevelByName(int level, string name)
    {
        if (level == 0)
        {
            return cantrips[name].Item1;
        }

        return spells[level - 1][name].Item1;
    }

    public Spell GetSpellByName(string name)
    {
        if (cantrips.ContainsKey(name))
        {
            return cantrips[name].Item1;
        }

        foreach (var level in spells)
        {
            if (level.ContainsKey(name))
            {
                return level[name].Item1;
            }
        }
        Debug.Log($"Spell of name {name} could not be found!");
        return new Spell();
    }
    
    public void RemoveSpellOfLevel(Spell spell, int level)
    {
        if (spell.level == 0)
        {
            cantrips.Remove(spell.name);
        }
        else
        {
            spells[level - 1].Remove(spell.name);
        }
    }
}

public class Spell
{
    public string name;
    public int level;
    public SchoolOfMagic school;
    public string castingTime;
    public string range;
    public string target;
    public string components;
    public string duration;
    public string description;
    public string higherLevels;
    public List<Class> classes;
    public bool ritual;
}

public enum SchoolOfMagic {
    Abjuration,
    Conjuration,
    Divination,
    Enchantment,
    Evocation,
    Illusion,
    Necromancy,
    Transmutation,
    Dunamancy,
}

public static class SchoolOfMagicExtensions
{
    public static string GetName(this SchoolOfMagic school)
    {
        return school switch
        {
            SchoolOfMagic.Abjuration => "Abjuration",
            SchoolOfMagic.Conjuration => "Conjuration",
            SchoolOfMagic.Divination => "Divination",
            SchoolOfMagic.Enchantment => "Enchantment",
            SchoolOfMagic.Evocation => "Evocation",
            SchoolOfMagic.Illusion => "Illusion",
            SchoolOfMagic.Necromancy => "Necromancy",
            SchoolOfMagic.Transmutation => "Transmutation",
            SchoolOfMagic.Dunamancy => "Dunamancy",
        };
    } 
}

public class JsonSpell
{
    public string name;
    public int level;
    public string school;
    public string castingTime;
    public string range;
    public string target;
    public string components;
    public string duration;
    public string description;
    public string higherLevels;
    public List<string> classes;
    public bool ritual;
}
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public Dictionary<string, Stat> stats;
    public int proficiencyBonus;
    
    public static Stats Default()
    {
        return new Stats
        {
            stats = new Dictionary<string, Stat>
            {
                { "Strength", new Stat(StatType.Strength, 8, false) },
                { "Dexterity", new Stat(StatType.Dexterity, 12, false) },
                { "Constitution", new Stat(StatType.Constitution, 14, true) },
                { "Intelligence", new Stat(StatType.Intelligence, 16, false) },
                { "Wisdom", new Stat(StatType.Wisdom, 18, true) },
                { "Charisma", new Stat(StatType.Charisma, 20, false) },
            }
        };
    }

    public Stat GetStat(StatType stat)
    {
        return stats[stat.ToString()];
    }
}

[Serializable]
public class Stat
{
    private StatType stat;

    public StatType StatType
    {
        get => stat;
        set => stat = value;
    }

    public int Value
    {
        get => value;
        set { 
            if (value < 1)
            {
                this.value = 1;
            }
            else
            {
                this.value = value;
                this.mod = Utils.StatToMod(value);
            } 
        }
    }

    public int Mod
    {
        get => mod;
        set => mod = value;
    }

    public bool SaveProficiency
    {
        get => saveProficiency;
        set => saveProficiency = value;
    }

    private int value;
    private int mod;
    private bool saveProficiency;

    public Stat(StatType stat, int value, bool saveProficiency)
    {
        this.stat = stat;
        this.value = value;
        this.mod = Utils.StatToMod(value);
        this.saveProficiency = saveProficiency;
    }

    public void AddOne()
    {
        value += 1;
    }

    public void SubtractOne()
    {
        value -= 1;
    }
 }

[Serializable]
public enum StatType
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma,
}

public static class StatTypeExtensions
{
    public static string GetName(this StatType stat)
    {
        return stat switch
        {
            StatType.Strength => "Strength",
            StatType.Dexterity => "Dexterity",
            StatType.Constitution => "Constitution",
            StatType.Intelligence => "Intelligence",
            StatType.Wisdom => "Wisdom",
            StatType.Charisma => "Charisma",
            _ => "-"
        };
    }

    public static string GetShortName(this StatType stat)
    {
        return stat switch
        {
            StatType.Strength => "STR",
            StatType.Dexterity => "DEX",
            StatType.Constitution => "CON",
            StatType.Intelligence => "INT",
            StatType.Wisdom => "WIS",
            StatType.Charisma => "CHA",
            _ => "-"
        };
    }

    public static Color GetStatColor(this StatType stat)
    {
        return stat switch
        {
            StatType.Strength => Utils.StrengthColor,
            StatType.Dexterity => Utils.DexterityColor,
            StatType.Constitution => Utils.ConstitutionColor,
            StatType.Intelligence => Utils.IntelligenceColor,
            StatType.Wisdom => Utils.WisdomColor,
            StatType.Charisma => Utils.CharismaColor,
            _ => Color.white
        };
    }

    public static StatType? FromString(string s)
    {
        s = s.ToLower();
        return s switch
        {
            "strength" => StatType.Strength,
            "dexterity" => StatType.Dexterity,
            "constitution" => StatType.Constitution,
            "intelligence" => StatType.Intelligence,
            "wisdom" => StatType.Wisdom,
            "charisma" => StatType.Charisma,
            _ => (StatType?)null
        };
    }
}
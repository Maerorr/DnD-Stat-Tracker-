using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Skills
{
    public Dictionary<string, Skill> skills;
    public int proficiencyBonus;
    [NonSerialized]
    public Character character;

    public static Skills Default()
    {
        return new Skills
        {
            skills = new Dictionary<string, Skill>
            {
                {"Acrobatics", new Skill(StatType.Dexterity, SkillType.Acrobatics, false, false, 0) },
                {"AnimalHandling", new Skill(StatType.Wisdom, SkillType.AnimalHandling, false, false, 0) },
                {"Arcana", new Skill(StatType.Intelligence, SkillType.Arcana, false, false, 0)},
                {"Athletics", new Skill(StatType.Strength, SkillType.Athletics, false, false, 0)},
                {"Deception", new Skill(StatType.Charisma, SkillType.Deception, false, false, 0)},
                {"History", new Skill(StatType.Intelligence, SkillType.History, false, false, 0)},
                {"Insight", new Skill(StatType.Wisdom, SkillType.Insight, false, false, 0)},
                {"Intimidation", new Skill(StatType.Charisma, SkillType.Intimidation, false, false, 0)},
                {"Investigation", new Skill(StatType.Intelligence, SkillType.Investigation, false, false, 0)},
                {"Medicine", new Skill(StatType.Wisdom, SkillType.Medicine, false, false, 0)},
                {"Nature", new Skill(StatType.Intelligence, SkillType.Nature, false, false, 0)},
                {"Perception", new Skill(StatType.Wisdom, SkillType.Perception, true, true, 0)},
                {"Performance", new Skill(StatType.Charisma, SkillType.Performance, false, true, 0)},
                {"Persuasion", new Skill(StatType.Charisma, SkillType.Persuasion, true, false, 0)},
                {"Religion", new Skill(StatType.Intelligence, SkillType.Religion, false, false, 0)},
                {"SleightofHand", new Skill(StatType.Dexterity, SkillType.SleightOfHand, false, false, 0)},
                {"Stealth", new Skill(StatType.Dexterity, SkillType.Stealth, false, false, 0)},
                {"Survival", new Skill(StatType.Wisdom, SkillType.Survival, false, false, 0)}
            }
        };
    }

    public void SetSkillExpertise(SkillType skillType, bool expertise)
    {
        skills[skillType.GetName()].expertise = expertise;
    }

    public bool GetSkillExpertise(SkillType skillType)
    {
        return skills[skillType.GetName()].expertise;
    }

    public void SetSkillProficiency(SkillType skillType, bool proficiency)
    {
        skills[skillType.GetName()].proficiency = proficiency;
    }
    
    public bool GetSkillProficiency(SkillType skillType)
    {
        return skills[skillType.GetName()].proficiency;
    }

    public StatType GetBaseStat(SkillType skillType)
    {
        return skills[skillType.GetName()].baseAbility;
    }

    public int GetSkillTotalMod(SkillType skillType)
    {
        int mod = 0;
        Skill temp = skills[skillType.GetDictionaryName()];
        mod += character.stats.stats[temp.baseAbility.GetName().Trim()].Mod;
        if (temp.proficiency) mod += proficiencyBonus;
        mod += temp.other_bonus;
        return mod;
    }
}

[Serializable]
public class Skill
{
    public StatType baseAbility;
    public SkillType skillType;
    public bool proficiency;
    public bool expertise;
    public int other_bonus;

    public Skill(StatType baseAbility, SkillType skillType, bool proficiency, bool expertise, int otherBonus)
    {
        this.baseAbility = baseAbility;
        this.skillType = skillType;
        this.proficiency = proficiency;
        this.expertise = expertise;
        other_bonus = otherBonus;
    }
}

[Serializable]
public enum SkillType
{
    Acrobatics,
    AnimalHandling,
    Arcana,
    Athletics,
    Deception,
    History,
    Insight,
    Intimidation,
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performance,
    Persuasion,
    Religion,
    SleightOfHand,
    Stealth,
    Survival
}

public static class SkillTypeExtensions
{
    public static string GetName(this SkillType skill)
    {
        return skill switch
        {
            SkillType.Acrobatics => "Acrobatics",
            SkillType.AnimalHandling => "Animal Handling",
            SkillType.Arcana => "Arcana",
            SkillType.Athletics => "Athletics",
            SkillType.Deception => "Deception",
            SkillType.History => "History",
            SkillType.Insight => "Insight",
            SkillType.Intimidation => "Intimidation",
            SkillType.Investigation => "Investigation",
            SkillType.Medicine => "Medicine",
            SkillType.Nature => "Nature",
            SkillType.Perception => "Perception",
            SkillType.Performance => "Performance",
            SkillType.Persuasion => "Persuasion",
            SkillType.Religion => "Religion",
            SkillType.SleightOfHand => "Sleight of Hand",
            SkillType.Stealth => "Stealth",
            SkillType.Survival => "Survival",
            _ => throw new ArgumentOutOfRangeException(nameof(skill), skill, null)
        };
    }

    public static string GetDictionaryName(this SkillType skill)
    {
        {
            return skill switch
            {
                SkillType.Acrobatics => "Acrobatics",
                SkillType.AnimalHandling => "AnimalHandling",
                SkillType.Arcana => "Arcana",
                SkillType.Athletics => "Athletics",
                SkillType.Deception => "Deception",
                SkillType.History => "History",
                SkillType.Insight => "Insight",
                SkillType.Intimidation => "Intimidation",
                SkillType.Investigation => "Investigation",
                SkillType.Medicine => "Medicine",
                SkillType.Nature => "Nature",
                SkillType.Perception => "Perception",
                SkillType.Performance => "Performance",
                SkillType.Persuasion => "Persuasion",
                SkillType.Religion => "Religion",
                SkillType.SleightOfHand => "SleightofHand",
                SkillType.Stealth => "Stealth",
                SkillType.Survival => "Survival",
                _ => throw new ArgumentOutOfRangeException(nameof(skill), skill, null)
            };
        }
    }

    public static StatType GetBaseStat(this SkillType skill)
    {
        return skill switch
        {
            SkillType.Acrobatics => StatType.Dexterity,
            SkillType.AnimalHandling => StatType.Wisdom,
            SkillType.Arcana => StatType.Intelligence,
            SkillType.Athletics => StatType.Strength,
            SkillType.Deception => StatType.Charisma,
            SkillType.History => StatType.Intelligence,
            SkillType.Insight => StatType.Wisdom,
            SkillType.Intimidation => StatType.Charisma,
            SkillType.Investigation => StatType.Intelligence,
            SkillType.Medicine => StatType.Wisdom,
            SkillType.Nature => StatType.Intelligence,
            SkillType.Perception => StatType.Wisdom,
            SkillType.Performance => StatType.Charisma,
            SkillType.Persuasion => StatType.Charisma,
            SkillType.Religion => StatType.Intelligence,
            SkillType.SleightOfHand => StatType.Dexterity,
            SkillType.Stealth => StatType.Dexterity,
            SkillType.Survival => StatType.Wisdom,
            _ => throw new ArgumentOutOfRangeException(nameof(skill), skill, null)
        };
    }

    public static SkillType? FromString(string skill)
    {
        return skill.ToLower() switch
        {
            "acrobatics" => SkillType.Acrobatics,
            "animal handling" => SkillType.AnimalHandling,
            "arcana" => SkillType.Arcana,
            "athletics" => SkillType.Athletics,
            "deception" => SkillType.Deception,
            "history" => SkillType.History,
            "insight" => SkillType.Insight,
            "intimidation" => SkillType.Intimidation,
            "investigation" => SkillType.Investigation,
            "medicine" => SkillType.Medicine,
            "nature" => SkillType.Nature,
            "perception" => SkillType.Perception,
            "performance" => SkillType.Performance,
            "persuasion" => SkillType.Persuasion,
            "religion" => SkillType.Religion,
            "sleight of hand" => SkillType.SleightOfHand,
            "stealth" => SkillType.Stealth,
            "survival" => SkillType.Survival,
            _ => (SkillType?)null
        };
    }
}
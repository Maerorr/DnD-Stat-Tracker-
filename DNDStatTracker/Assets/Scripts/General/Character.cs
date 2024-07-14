using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterName;
    public int level;
    public Class characterClass;

    public int experience;
    public int baseArmorClass;
    public int initiativeBonus;
    public int speed;

    public int maxHP;
    public int currentHP;
    public int temporaryHP;

    public Dice hitDiceTotal;
    public Dice hitDiceUsed;
    // public DeathSaves deathSaves;
    public bool inspiration;

    public int proficiencyBonus;
    public Stats stats;
    public Skills skills;

    /*public Character(string characterName, int level, Class characterClass, int experience, int baseArmorClass, int initiativeBonus, int speed, int maxHp, int currentHp, int temporaryHp, Dice hitDiceTotal, Dice hitDiceUsed, bool inspiration, int proficiencyBonus, Stats stats, Skills skills)
    {
        this.characterName = characterName;
        this.level = level;
        this.characterClass = characterClass;
        this.experience = experience;
        this.baseArmorClass = baseArmorClass;
        this.initiativeBonus = initiativeBonus;
        this.speed = speed;
        maxHP = maxHp;
        currentHP = currentHp;
        temporaryHP = temporaryHp;
        this.hitDiceTotal = hitDiceTotal;
        this.hitDiceUsed = hitDiceUsed;
        this.inspiration = inspiration;
        this.proficiencyBonus = proficiencyBonus;
        this.stats = stats;
        this.skills = skills;
    }*/

    public static Character Default()
    {
        return new Character
        {
            characterName = "Default Name",
            level = 10,
            characterClass = Class.Barbarian,
            experience = 123456,
            baseArmorClass = 15,
            initiativeBonus = 5,
            speed = 30,
            maxHP = 50,
            currentHP = 45,
            temporaryHP = 5,
            hitDiceTotal = new Dice(12, 10),
            hitDiceUsed = new Dice(12, 1),
            inspiration = false,
            proficiencyBonus = 5,
            stats = Stats.Default(),
            skills = Skills.Default(),
        };
    }
}

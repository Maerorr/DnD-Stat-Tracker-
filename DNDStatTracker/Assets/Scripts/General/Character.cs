using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class Character
{
    public string characterName;
    public int level;
    public Class characterClass;

    public int experience;
    public int armorClass;
    public int initiativeBonus;
    public int speed;

    public int maxHP;
    public int currentHP;
    public int temporaryHP;

    public Dice hitDiceTotal;
    public Dice hitDiceLeft;
    public DeathSaves deathSaves;
    public bool inspiration;

    public int proficiencyBonus;
    public Stats stats;
    public Skills skills;

    public string languageProficiencies;
    public string weaponsProficiencies;
    public string armorProficiencies;
    public string toolsProficiencies;
    
    public Money money;
    
    public String featuresAndTraits;

    [JsonIgnore]
    public Spells spellList;

    public List<int> spellSlotsMax;
    public List<int> spellSlotsUsed;
    
    public static Character Default()
    {
        Spells spellList = new Spells();
        Spell spell1 = new Spell
        {
            name = "Test Spell 1 with very long name that should be 2 lines",
            level = 0,
            school = SchoolOfMagic.Abjuration,
            castingTime = "1 round",
            range = "30ft",
            target = "self",
            components = "V,S,M",
            duration = "1 minute",
            description =
                "a long-ass spell description that says everything\nthere is to\nsay about this complex spell.",
            higherLevels = "nothing, cant be cast at higher levels",
            classes = new List<Class> { Class.Cleric, Class.Cleric },
            ritual = false,
        };
        spellList.AddSpell(spell1, true);
        spell1 = new Spell
        {
            name = "Test Spell 2",
            level = 1,
            school = SchoolOfMagic.Dunamancy,
            castingTime = "instant",
            range = "45ft",
            target = "self",
            components = "V,S,M",
            duration = "1 minute",
            description =
                "a long-ass spell description that says everything\nthere is to\nsay about this complex spell.",
            higherLevels = "nothing, cant be cast at higher levels",
            classes = new List<Class> { Class.Cleric, Class.Cleric },
            ritual = false,
        };
        spellList.AddSpell(spell1, true);
        
        return new Character
        {
            characterName = "Default Name",
            level = 10,
            characterClass = Class.Barbarian,
            experience = 123456,
            armorClass = 15,
            initiativeBonus = 5,
            speed = 30,
            maxHP = 50,
            currentHP = 45,
            temporaryHP = 0,
            hitDiceTotal = new Dice(12, 10),
            hitDiceLeft = new Dice(12, 9),
            deathSaves = new DeathSaves(),
            inspiration = false,
            proficiencyBonus = Utils.ProficiencyBonus(10),
            stats = Stats.Default(),
            skills = Skills.Default(),
            languageProficiencies = "Common, Sylvan, Gnommish.",
            weaponsProficiencies = "Simple and Martial weapons.",
            armorProficiencies = "Light and Medium armor.",
            toolsProficiencies = "Thieves' tools",
            featuresAndTraits =
                "Feats:\n-Keen Mind\n- You know which way is north\n- You can recall every bit of information you came across from the past month.",
            money = new Money(10, 10, 10, 10, 10),
            spellList = spellList,
            spellSlotsMax = new List<int>{4, 3, 2, 1, 0, 0, 0, 0, 0},
            spellSlotsUsed = new List<int>{2, 1, 2, 0, 0, 0, 0, 0, 0},
        };
    }

    public void Init()
    {
        proficiencyBonus = Utils.ProficiencyBonus(level);
        skills.proficiencyBonus = proficiencyBonus;
        skills.character = this;
        stats.proficiencyBonus = proficiencyBonus;
    }

    public int GetTotalArmorClass()
    {
        return armorClass + stats.stats["Dexterity"].Mod;
    }

    public int GetTotalInitiative()
    {
        return initiativeBonus + stats.stats["Dexterity"].Mod;
    }
}

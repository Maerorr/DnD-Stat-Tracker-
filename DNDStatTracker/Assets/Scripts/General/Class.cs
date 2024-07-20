using System;

[Serializable]
public enum Class
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard,
    Artificer,
    BloodHunter,
    Gunslinger
}

public static class ClassExtensions
{
    public static Dice GetHitDice(this Class characterClass)
    {
        return characterClass switch
        {
            Class.Barbarian => new Dice(12, 1),
            Class.Bard => new Dice(8, 1),
            Class.Cleric => new Dice(8, 1),
            Class.Druid => new Dice(8, 1),
            Class.Fighter => new Dice(10, 1),
            Class.Monk => new Dice(8, 1),
            Class.Paladin => new Dice(10, 1),
            Class.Ranger => new Dice(10, 1),
            Class.Rogue => new Dice(8, 1),
            Class.Sorcerer => new Dice(6, 1),
            Class.Warlock => new Dice(8, 1),
            Class.Wizard => new Dice(6, 1),
            Class.Artificer => new Dice(8, 1),
            Class.BloodHunter => new Dice(10, 1),
            Class.Gunslinger => new Dice(10, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(characterClass), characterClass, null)
        };
    }

    public static string GetName(this Class characterClass)
    {
        return characterClass switch
        {
            Class.Barbarian => "Barbarian",
            Class.Bard => "Bard",
            Class.Cleric => "Cleric",
            Class.Druid => "Druid",
            Class.Fighter => "Fighter",
            Class.Monk => "Monk",
            Class.Paladin => "Paladin",
            Class.Ranger => "Ranger",
            Class.Rogue => "Rogue",
            Class.Sorcerer => "Sorcerer",
            Class.Warlock => "Warlock",
            Class.Wizard => "Wizard",
            Class.Artificer => "Artificer",
            Class.BloodHunter => "Blood Hunter",
            Class.Gunslinger => "Gunslinger",
            _ => throw new ArgumentOutOfRangeException(nameof(characterClass), characterClass, null)
        };
    }

    public static StatType? GetSpellcastingAbility(this Class characterClass)
    {
        return characterClass switch
        {
            Class.Barbarian => null,
            Class.Bard => StatType.Charisma,
            Class.Cleric => StatType.Wisdom,
            Class.Druid => StatType.Wisdom,
            Class.Fighter => null,
            Class.Monk => null,
            Class.Paladin => StatType.Charisma,
            Class.Ranger => StatType.Wisdom,
            Class.Rogue => null,
            Class.Sorcerer => StatType.Charisma,
            Class.Warlock => StatType.Charisma,
            Class.Wizard => StatType.Intelligence,
            Class.Artificer => StatType.Intelligence,
            Class.BloodHunter => StatType.Wisdom,
            Class.Gunslinger => StatType.Wisdom,
            _ => throw new ArgumentOutOfRangeException(nameof(characterClass), characterClass, null)
        };
    }
}
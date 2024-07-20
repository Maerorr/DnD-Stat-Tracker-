using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDisplay : MonoBehaviour
{
    [SerializeField] private GameObject spells012Root;
    [SerializeField] private GameObject spells345Root;
    [SerializeField] private GameObject spells6789Root;

    [SerializeField] private GameObject spellEntryPrefab;
    [SerializeField] private GameObject spellLevelSeparatorPrefab;
    
    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacter(Character character)
    {
        c = character;
        SpawnSpells();
    }

    private void Clear()
    {
        foreach (Transform child in spells012Root.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spells345Root.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spells6789Root.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void SpawnSpells()
    {
        Clear();
        int level = 0;
        
        // CANTRIPS
        var cantrips = c.spellList.GetSpellsOfLevel(level);

        var sep = Instantiate(spellLevelSeparatorPrefab, spells012Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var cantrip in cantrips.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells012Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(cantrip.Item1, cantrip.Item2);
        }

        level++;
        // SPELLS LEVEL 1
        var spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells012Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells012Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 2
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells012Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells012Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 3
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells345Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells345Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELL LEVEL 4
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells345Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells345Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 5
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells345Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells345Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 6
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells6789Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells6789Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 7
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells6789Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells6789Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 8
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells6789Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells6789Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
        
        level++;
        // SPELLS LEVEL 6
        spells = c.spellList.GetSpellsOfLevel(level);

        sep = Instantiate(spellLevelSeparatorPrefab, spells6789Root.transform);
        sep.GetComponent<SpellLevelHeader>().SetCharacterAndLevel(c, level);
        
        foreach (var spell in spells.Values)
        {
            var spellEntry = Instantiate(spellEntryPrefab, spells6789Root.transform);
            spellEntry.GetComponent<SpellEntry>().SetSpell(spell.Item1, spell.Item2);
        }
    }
}

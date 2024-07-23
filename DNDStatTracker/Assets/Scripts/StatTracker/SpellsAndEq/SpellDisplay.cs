using System.Collections.Generic;
using UnityEngine;

public class SpellDisplay : MonoBehaviour, IEditable
{
    [SerializeField] private GameObject spells012Root;
    [SerializeField] private GameObject spells345Root;
    [SerializeField] private GameObject spells6789Root;

    [SerializeField] private GameObject spellEntryPrefab;
    [SerializeField] private GameObject spellLevelSeparatorPrefab;

    [SerializeField] private GameObject spellAddPrefab;
    private List<GameObject> spawnedSpellAdds = new List<GameObject>();
    [SerializeField] private SpellPicker spellPicker;

    private bool editMode = false;
    
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
        spawnedSpellAdds.ForEach(entry => entry.SetActive(false));
        spellPicker.SetCharacter(character);
    }

    public void UpdateSpells()
    {
        SpawnSpells();
        spawnedSpellAdds.ForEach(entry => entry.SetActive(editMode));
    }

    private void Clear()
    {
        spawnedSpellAdds.Clear();
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
        var spellAdd = Instantiate(spellAddPrefab, spells012Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(0, spellPicker);
        spawnedSpellAdds.Add(spellAdd);

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
        spellAdd = Instantiate(spellAddPrefab, spells012Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(1, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells012Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(2, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells345Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(3, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells345Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(4, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells345Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(5, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells6789Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(6, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells6789Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(7, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells6789Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(8, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
        
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
        spellAdd = Instantiate(spellAddPrefab, spells6789Root.transform);
        spellAdd.GetComponent<SpellAddEntry>().SetData(9, spellPicker);
        spawnedSpellAdds.Add(spellAdd);
    }

    public void ToggleEditMode(bool edit)
    {
        editMode = edit;
        spawnedSpellAdds.ForEach(entry => entry.SetActive(edit));
    }
}

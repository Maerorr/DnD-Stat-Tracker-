using System.Collections.Generic;
using UnityEngine;

public class SavingThrowsSpawner : MonoBehaviour
{
    public GameObject savesEntryPrefab;
    public Transform spawnRoot;

    private Character currectCharacter;
    private List<SaveEntry> spawnedEntries = new List<SaveEntry>();
    
    private void ClearEntries() {
        // clear the children
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void SetCharacter(Character character)
    {
        currectCharacter = character;
        ClearEntries();
        SpawnEntries(currectCharacter.stats);
    }

    public void UpdateSaves()
    {
        foreach (var entry in spawnedEntries)
        {
            var save = currectCharacter.stats.stats[Utils.RemoveStringWhitespace(entry.GetName())];
            int mod = save.Mod;
            if (save.SaveProficiency) mod += currectCharacter.stats.proficiencyBonus;
            entry.SetEntryData(save.StatType, mod, save.SaveProficiency);
        }
    }
    
    private void SpawnEntries(Stats stats)
    {
        foreach (var stat in stats.stats)
        {
            Stat tempStat = stat.Value;
            var statEntry = Instantiate(savesEntryPrefab, spawnRoot);
            statEntry.name = "STAT_" + stat.Value.StatType.GetName();
            int mod = tempStat.Mod;
            if (tempStat.SaveProficiency) mod += stats.proficiencyBonus;

            SaveEntry e = statEntry.GetComponent<SaveEntry>();
            e.SetEntryData(tempStat.StatType, mod, tempStat.SaveProficiency);
            spawnedEntries.Add(e);
        }
    }
}

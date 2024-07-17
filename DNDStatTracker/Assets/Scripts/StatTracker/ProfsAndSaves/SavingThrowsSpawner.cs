using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingThrowsSpawner : MonoBehaviour
{
    public GameObject savesEntryPrefab;
    public Transform spawnRoot;

    private Character currectCharacter;
    
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
    
    private void SpawnEntries(Stats stats)
    {
        foreach (var stat in stats.stats)
        {
            Stat tempStat = stat.Value;
            var statEntry = Instantiate(savesEntryPrefab, spawnRoot);
            statEntry.name = "STAT_" + stat.Value.StatType.GetName();
            int mod = tempStat.Mod;
            if (tempStat.SaveProficiency) mod += stats.proficiencyBonus;
            statEntry.GetComponent<SaveEntry>().SetEntryData(tempStat.StatType, mod, tempStat.SaveProficiency);
        }
    }
}

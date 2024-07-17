using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingThrowsSpawner : MonoBehaviour
{
    public GameObject savesEntryPrefab;
    public Transform spawnRoot;
    
    private void Awake()
    {
        // clear the children
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void SpawnEntries(Stats stats, int profBonus)
    {
        foreach (var stat in stats.stats)
        {
            Stat tempStat = stat.Value;
            var statEntry = Instantiate(savesEntryPrefab, spawnRoot);
            statEntry.name = "STAT_" + stat.Value.StatType.GetName();
            int mod = tempStat.Mod;
            if (tempStat.SaveProficiency) mod += profBonus;
            statEntry.GetComponent<SaveEntry>().SetEntryData(tempStat.StatType, mod, tempStat.SaveProficiency);
        }
    }
}

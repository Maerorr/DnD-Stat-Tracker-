using System.Collections.Generic;
using UnityEngine;

public class StatsSpawner : MonoBehaviour
{
    public GameObject statsEntryPrefab;
    public Transform spawnRoot;

    private Character currentCharacter;
    private List<StatEntry> spawnedEntries = new List<StatEntry>();

    private void ClearEntries()
    {
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetCharacter(Character character)
    {
        currentCharacter = character;
        ClearEntries();
        SpawnEntries(currentCharacter.stats);
    }

    public void UpdateStatEntries()
    {
        foreach (var entry in spawnedEntries)
        {
            var stat = currentCharacter.stats.stats[entry.GetName()];
            entry.SetStatData(stat.StatType, stat.Value, currentCharacter);
        }
    }

    private void SpawnEntries(Stats stats)
    {
        foreach (var stat in stats.stats)
        {
            Stat tempStat = stat.Value;
            var statEntry = Instantiate(statsEntryPrefab, spawnRoot);
            statEntry.name = "STAT_" + stat.Value.StatType.GetName();
            StatEntry entry = statEntry.GetComponent<StatEntry>();
            entry.SetStatData(tempStat.StatType, tempStat.Value, currentCharacter);
            spawnedEntries.Add(entry);
        }
    }
}

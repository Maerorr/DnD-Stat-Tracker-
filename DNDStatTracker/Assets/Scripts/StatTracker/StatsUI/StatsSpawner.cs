using UnityEngine;

public class StatsSpawner : MonoBehaviour
{
    public GameObject statsEntryPrefab;
    public Transform spawnRoot;

    private Character currentCharacter;

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

    private void SpawnEntries(Stats stats)
    {
        foreach (var stat in stats.stats)
        {
            Stat tempStat = stat.Value;
            var statEntry = Instantiate(statsEntryPrefab, spawnRoot);
            statEntry.name = "STAT_" + stat.Value.StatType.GetName();
            statEntry.GetComponent<StatEntry>().SetStatData(tempStat.StatType, tempStat.Value);
        }
    }
}

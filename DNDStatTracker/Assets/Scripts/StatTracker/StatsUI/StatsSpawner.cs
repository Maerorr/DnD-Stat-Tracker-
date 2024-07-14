using UnityEngine;

public class StatsSpawner : MonoBehaviour
{
    public GameObject statsEntryPrefab;
    public Transform spawnRoot;

    private void Awake()
    {
        // clear the children
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SpawnEntries(Stats stats)
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

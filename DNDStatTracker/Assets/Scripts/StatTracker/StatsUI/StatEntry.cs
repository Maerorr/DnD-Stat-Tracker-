using TMPro;
using UnityEngine;

public class StatEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statName;
    [SerializeField] private TextMeshProUGUI statValue;
    [SerializeField] private TextMeshProUGUI statModifier;

    public void SetStatData(StatType stat, int val)
    {
        this.statName.text = stat.GetName();
        this.statName.color = stat.GetStatColor();
        statValue.text = $"{val}";
        int mod = Utils.StatToMod(val);
        statModifier.text = mod >= 0 ? $"(+{mod})" : $"({mod})";
    }
}

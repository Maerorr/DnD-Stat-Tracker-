using TMPro;
using UnityEngine;

public class SaveEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveName;
    [SerializeField] private TextMeshProUGUI saveMod;
    [SerializeField] private Checkbox checkbox;

    public void SetEntryData(StatType stat, int mod, bool proficiency)
    {
        saveName.text = stat.GetName();
        saveName.color = stat.GetStatColor();
        string sign = mod > 0 ? "+" : "";
        saveMod.text = $"({sign}{mod})";
        checkbox.SetActive(proficiency);
    }
}

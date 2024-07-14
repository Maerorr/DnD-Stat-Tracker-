using System.Collections;
using System.Collections.Generic;
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
        saveMod.text = $"{mod}";
        checkbox.SetActive(proficiency);
    }
}

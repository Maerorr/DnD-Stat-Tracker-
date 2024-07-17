using UnityEngine;
using TMPro;

public class ProficiencyEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI mod;
    [SerializeField] private Checkbox checkbox;
    [SerializeField] private TextMeshProUGUI baseStat;
    [SerializeField] private TextMeshProUGUI expertise;

    public void SetEntryData(SkillType skill, int mod, bool proficiency, StatType baseStat, bool expertise)
    {
        skillName.text = skill.GetName();
        skillName.color = baseStat.GetStatColor();
        string sign = mod > 0 ? "+" : "";
        this.mod.text = $"({sign}{mod})";
        checkbox.SetActive(proficiency);
        this.baseStat.text = $"({baseStat.GetShortName()})";
        this.baseStat.color = baseStat.GetStatColor();
        this.expertise.text = expertise ? "e" : "";
    }
}

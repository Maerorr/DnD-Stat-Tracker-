using System;
using UnityEngine;
using TMPro;

public class ProficiencyEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI mod;
    [SerializeField] private Checkbox checkbox;
    [SerializeField] private Checkbox expertiseCheckbox;
    [SerializeField] private TextMeshProUGUI baseStat;
    [SerializeField] private TextMeshProUGUI expertise;
    private Character c;
    private StatTracker st;

    private void Start()
    {
        checkbox.toggle.onValueChanged.AddListener(OnProficiencyChanged);
        expertiseCheckbox.toggle.onValueChanged.AddListener(OnExpertiseChanged);
        st = FindAnyObjectByType<StatTracker>();
    }

    public string GetName()
    {
        return skillName.text;
    }

    public void OnProficiencyChanged(bool val)
    {
        c.skills.skills[Utils.RemoveStringWhitespace(skillName.text)].proficiency = val;
        st.UpdateProficiencies();
    }

    public void OnExpertiseChanged(bool val)
    {
        Debug.Log("Expertise changed");
        c.skills.skills[Utils.RemoveStringWhitespace(skillName.text)].expertise = val;
        st.UpdateProficiencies();
    }

    public void SetEntryData(SkillType skill, int mod, bool proficiency, StatType baseStat, bool expertise, Character c)
    {
        skillName.text = skill.GetName();
        skillName.color = baseStat.GetStatColor();
        string sign = mod > 0 ? "+" : "";
        this.mod.text = $"({sign}{mod})";
        checkbox.SetActive(proficiency);
        expertiseCheckbox.SetActive(expertise);
        this.baseStat.text = $"({baseStat.GetShortName()})";
        this.baseStat.color = baseStat.GetStatColor();
        this.expertise.text = expertise ? "e" : "";
        this.c = c;
    }
    
    
}

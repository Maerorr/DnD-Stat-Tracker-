using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatEntry : MonoBehaviour, IEditable
{
    [SerializeField] private TextMeshProUGUI statName;
    [SerializeField] private TextMeshProUGUI statValue;
    [SerializeField] private TextMeshProUGUI statModifier;
    [SerializeField] private List<GameObject> buttons;
    private bool editMode = false;
    private Character c;
    private StatTracker st;
    
    public void SetStatData(StatType stat, int val, Character character)
    {
        c = character;
        st = FindAnyObjectByType<StatTracker>();
        this.statName.text = stat.GetName();
        this.statName.color = stat.GetStatColor();
        statValue.text = $"{val}";
        int mod = Utils.StatToMod(val);
        statModifier.text = mod >= 0 ? $"(+{mod})" : $"({mod})";
        buttons.ForEach(button => button.SetActive(editMode));
    }

    public void ToggleEditMode(bool edit)
    {
        editMode = edit;
        buttons.ForEach(button => button.SetActive(editMode));
    }

    public string GetName()
    {
        return statName.text;
    }
    
    public void OnAdd()
    {
        c.stats.stats[statName.text].AddOne();
        st.UpdateStats();
    }

    public void OnSub()
    {
        c.stats.stats[statName.text].SubtractOne();
        st.UpdateStats();
    }
}

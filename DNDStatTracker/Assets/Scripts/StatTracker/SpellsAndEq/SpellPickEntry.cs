using TMPro;
using UnityEngine;

public class SpellPickEntry : MonoBehaviour
{
    private string spellName;
    private int spellLevel;
    private SpellPicker picker;
    [SerializeField] private TextMeshProUGUI uiName;

    public void SetSpellData(string spellName, int level, SpellPicker picker)
    {
        this.picker = picker;
        spellLevel = level;
        this.spellName = spellName;
        uiName.text = this.spellName;
    }

    public void OnSpellAddPress()
    {
        picker.OnAddSpell(spellName, spellLevel);
    }
}

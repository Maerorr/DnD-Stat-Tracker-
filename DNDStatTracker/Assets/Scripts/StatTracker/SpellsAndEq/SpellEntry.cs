using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI spellName;
    [SerializeField] private Checkbox checkbox;
    private Spell spell;
    private StatTracker st;
    private RectTransform rect;

    public GameObject infoPanel;
    
    private void Awake()
    {
        st = FindAnyObjectByType<StatTracker>();
        rect = GetComponent<RectTransform>();
    }

    public void SetSpell(Spell spell, bool prepared)
    {
        this.spell = spell;
        spellName.text = spell.name;
        //spellName.autoSizeTextContainer = true;
        checkbox.SetActive(prepared);
        Vector2 prefferedSize = spellName.GetPreferredValues();
        if (prefferedSize.y > rect.sizeDelta.y)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, prefferedSize.y * 1.1f);
        }
        
    }

    public void OnToggleInfo()
    {
        
    }

    public void OnSetSpellPrepared(bool val)
    {
        
    }
}

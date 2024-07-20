using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellLevelHeader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI spellSlots;
    [SerializeField] private GameObject slotsAndButtons;
    private int level;
    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacterAndLevel(Character character, int level)
    {
        c = character;
        this.level = level;
        if (level == 0)
        {
            levelText.text = $"Cantrips";
            spellSlots.text = $"";
            slotsAndButtons.SetActive(false);
        }
        else
        {
            levelText.text = $"Level {this.level}";
            spellSlots.text = $"{c.spellSlotsUsed[level - 1]}/{c.spellSlotsMax[level - 1]}";
        }
        
    }

    public void OnUseSpellSlot()
    {
        
    }

    public void OnAddSpellSlot()
    {
        
    }
}

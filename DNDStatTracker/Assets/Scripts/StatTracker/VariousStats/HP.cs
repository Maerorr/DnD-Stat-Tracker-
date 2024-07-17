using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxHP;
    [SerializeField] private TextMeshProUGUI currentHP;
    [SerializeField] private TextMeshProUGUI tempHP;
    [SerializeField] private TMP_InputField input;
    private int currentInput;
    
    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacter(Character character)
    {
        c = character;
        maxHP.text = $"{c.maxHP}";
        currentHP.text = $"{c.currentHP}";
        tempHP.text = $"{c.temporaryHP}";
    }

    public void OnInputChanged(String input)
    {
        if (input.Length == 0)
        {
            currentInput = 0;
        } else 
        {
            currentInput = int.Parse(input);
        }
    }

    public void Damage()
    {
        int damage = currentInput;
        if (damage <= 0) return;
        if (c.temporaryHP > 0)
        {
            c.temporaryHP -= damage;
            if (c.temporaryHP < 0)
            {
                c.currentHP += c.temporaryHP;
                c.temporaryHP = 0;
            }
            st.UpdateHP();
            return;
        }

        int exceed = 0;
        if (c.currentHP >= damage)
        {
            c.currentHP -= damage;
        }
        else
        {
            exceed = damage - c.currentHP;
            c.currentHP = 0;
        }

        if (c.currentHP < 0)
        {
            c.currentHP = 0;
        }

        if (c.currentHP == 0 && exceed > c.maxHP)
        {
            // meaning character is dead dead.
            c.currentHP = -9999;
        }
        
        st.UpdateHP();
    }

    public void Heal()
    {
        int heal = currentInput;
        if (heal <= 0) return;

        c.currentHP += heal;
        c.currentHP = Math.Clamp(c.currentHP, 0, c.maxHP);
        st.UpdateHP();
    }

    public void AddTempHP()
    {
        int temp = currentInput;
        if (temp <= 0) return;
        c.temporaryHP += temp;
        st.UpdateHP();
    }

    public void SubtractTempHP()
    {
        int temp = currentInput;
        if (temp <= 0) return;
        c.temporaryHP -= temp;
        c.temporaryHP = Math.Clamp(c.temporaryHP, 0, int.MaxValue);
        st.UpdateHP();
    }
    
}

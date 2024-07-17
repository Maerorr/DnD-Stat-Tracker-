using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDiceDeathSaves : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxHitDice;
    [SerializeField] private TextMeshProUGUI leftHitDice;
    
    [SerializeField] private List<Checkbox> successes;
    [SerializeField] private List<Checkbox> failures;
    
    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacter(Character character)
    {
        c = character;
        maxHitDice.text = c.hitDiceTotal.ToString();
        leftHitDice.text = c.hitDiceLeft.ToString();
    }

    public void UseHitDie()
    {
        if (c.hitDiceLeft.count == 0) return;
        c.hitDiceLeft.count -= 1;
        st.UpdateHitDieAndDeathSaves();
    }

    public void ResetHitDie()
    {
        c.hitDiceLeft.count = c.hitDiceTotal.count;
        st.UpdateHitDieAndDeathSaves();
    }

    public void AddSuccess()
    {
        c.deathSaves.successes++;
        for (int i = 0; i < c.deathSaves.successes; i++)
        {
            successes[i].SetActive(true);
        }
        st.UpdateHitDieAndDeathSaves();
    }
    
    public void AddFailure()
    {
        c.deathSaves.failures++;
        for (int i = 0; i < c.deathSaves.failures; i++)
        {
            failures[i].SetActive(true);
        }
        st.UpdateHitDieAndDeathSaves();
    }

    public void ResetDeathSaves()
    {
        c.deathSaves.failures = 0;
        c.deathSaves.successes = 0;
        for (int i = 0; i < 3; i++)
        {
            successes[i].SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            failures[i].SetActive(false);
        }
        st.UpdateHitDieAndDeathSaves();
    }
}

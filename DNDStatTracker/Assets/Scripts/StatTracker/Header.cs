using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterLevel;
    [SerializeField] private TextMeshProUGUI characterProfBonus;
    [SerializeField] private TextMeshProUGUI characterClass;
    [SerializeField] private TextMeshProUGUI characterExperience;

    public void SetHeaderData(string characterName, int level, int profBonus, Class characterClass, int exp)
    {
        this.characterName.text = $"Name: {characterName}";
        this.characterLevel.text = $"Level: {level}";
        string sign = profBonus > 0 ? "+" : "-";
        this.characterProfBonus.text = $"Proficiency Bonus: {sign}{profBonus}";
        this.characterClass.text = $"Class: {characterClass.GetName()}";
        this.characterExperience.text = $"Experience: {exp}";
    }
}

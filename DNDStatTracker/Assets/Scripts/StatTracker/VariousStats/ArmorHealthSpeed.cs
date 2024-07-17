using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmorHealthSpeed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ac;
    [SerializeField] private TextMeshProUGUI initiative;
    [SerializeField] private TextMeshProUGUI speed;
    private Character currentCharacter;

    public void SetCharacter(Character character)
    {
        currentCharacter = character;

        ac.text = $"{currentCharacter.GetTotalArmorClass()}";
        int init = currentCharacter.GetTotalInitiative();
        string sign = init > 0 ? "+" : "";
        initiative.text = $"{sign}{init}";
        speed.text = $"{currentCharacter.speed}ft.";
    }
}

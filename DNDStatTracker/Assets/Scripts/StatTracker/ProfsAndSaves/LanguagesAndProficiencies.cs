using TMPro;
using UnityEngine;

public class LanguagesAndProficiencies : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI languages;
    [SerializeField] private TextMeshProUGUI weapons;
    [SerializeField] private TextMeshProUGUI armor;
    [SerializeField] private TextMeshProUGUI tools;

    private Character currentCharacter;

    public void SetCharacter(Character character)
    {
        currentCharacter = character;
        languages.text = $"Languages: {character.languageProficiencies}";
        weapons.text = $"Weapons: {character.weaponsProficiencies}";
        armor.text = $"Armor: {character.armorProficiencies}";
        tools.text = $"Tools: {character.toolsProficiencies}";
    }
}

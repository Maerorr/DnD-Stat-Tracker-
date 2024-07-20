using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProficienciesSpawner : MonoBehaviour
{
    public GameObject proficienciesSpawner;
    public Transform spawnRoot;
    private Character currentCharacter;
    private List<ProficiencyEntry> spawnedProficiencies = new List<ProficiencyEntry>();
    
    private void ClearEntries()
    {
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetCharacter(Character character)
    {
        currentCharacter = character;
        ClearEntries();
        SpawnEntries(currentCharacter.skills);
    }

    public void UpdateSkillProficiencies()
    {
        foreach (var entry in spawnedProficiencies)
        {
            var tempSkill = currentCharacter.skills.skills[Utils.RemoveStringWhitespace(entry.GetName())];
            entry.SetEntryData(
                tempSkill.skillType,
                currentCharacter.skills.GetSkillTotalMod(tempSkill.skillType),
                tempSkill.proficiency,
                tempSkill.baseAbility,
                tempSkill.expertise,
                currentCharacter
            );
        }
    } 
    
    private void SpawnEntries(Skills skills)
    {
        foreach (var skill in skills.skills)
        {
            Skill tempSkill = skill.Value;
            var statEntry = Instantiate(proficienciesSpawner, spawnRoot);
            
            statEntry.name = "SKILL_" + tempSkill.skillType.GetName();
            ProficiencyEntry entry = statEntry.GetComponent<ProficiencyEntry>();
            spawnedProficiencies.Add(entry);
            entry.SetEntryData(
                    tempSkill.skillType,
                    skills.GetSkillTotalMod(tempSkill.skillType),
                    tempSkill.proficiency,
                    tempSkill.baseAbility,
                    tempSkill.expertise,
                    currentCharacter
                );
        }
    }
}

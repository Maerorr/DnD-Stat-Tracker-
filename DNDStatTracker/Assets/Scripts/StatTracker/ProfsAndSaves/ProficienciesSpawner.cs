using UnityEngine;

public class ProficienciesSpawner : MonoBehaviour
{
    public GameObject proficienciesSpawner;
    public Transform spawnRoot;
    private Character currentCharacter;
    
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
    
    private void SpawnEntries(Skills skills)
    {
        foreach (var skill in skills.skills)
        {
            Skill tempSkill = skill.Value;
            var statEntry = Instantiate(proficienciesSpawner, spawnRoot);
            statEntry.name = "SKILL_" + tempSkill.skillType.GetName();
            statEntry.GetComponent<ProficiencyEntry>().SetEntryData(
                    tempSkill.skillType,
                    skills.GetSkillTotalMod(tempSkill.skillType),
                    tempSkill.proficiency,
                    tempSkill.baseAbility,
                    tempSkill.expertise
                );
        }
    }
}

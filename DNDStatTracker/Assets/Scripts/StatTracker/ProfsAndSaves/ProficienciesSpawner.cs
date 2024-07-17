using UnityEngine;

public class ProficienciesSpawner : MonoBehaviour
{
    public GameObject proficienciesSpawner;
    public Transform spawnRoot;
    
    private void Awake()
    {
        // clear the children
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void SpawnEntries(Skills skills)
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

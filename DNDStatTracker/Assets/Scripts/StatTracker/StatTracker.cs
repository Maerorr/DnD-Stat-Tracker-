using UnityEngine;

public class StatTracker : MonoBehaviour
{
    private Character currentCharacter;

    public Header header;
    public StatsSpawner statsSpawner;
    public SavingThrowsSpawner savesSpawner;
    public ProficienciesSpawner proficienciesSpawner;

    private void Start()
    {
        currentCharacter = Character.Default();
        currentCharacter.Init();
        
        header.SetHeaderData(currentCharacter.characterName, currentCharacter.level, currentCharacter.proficiencyBonus, currentCharacter.characterClass, currentCharacter.experience);
        statsSpawner.SpawnEntries(currentCharacter.stats);
        savesSpawner.SpawnEntries(currentCharacter.stats, currentCharacter.proficiencyBonus);
        proficienciesSpawner.SpawnEntries(currentCharacter.skills);
    }
}

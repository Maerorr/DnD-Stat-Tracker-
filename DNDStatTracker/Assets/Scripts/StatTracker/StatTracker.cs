using UnityEngine;

public class StatTracker : MonoBehaviour
{
    private Character currentCharacter;

    public Header header;
    public StatsSpawner statsSpawner;
    public SavingThrowsSpawner savesSpawner;
    public ProficienciesSpawner proficienciesSpawner;
    public LanguagesAndProficiencies languagesAndProficiencies;
    public ArmorHealthSpeed achpspeed;
    public HP hp;

    private void Start()
    {
        currentCharacter = Character.Default();
        currentCharacter.Init();
        
        header.SetCharacter(currentCharacter);
        statsSpawner.SetCharacter(currentCharacter);
        
        savesSpawner.SetCharacter(currentCharacter);
        proficienciesSpawner.SetCharacter(currentCharacter);
        languagesAndProficiencies.SetCharacter(currentCharacter);
        
        achpspeed.SetCharacter(currentCharacter);
        hp.SetCharacter(currentCharacter);
    }

    public void UpdateHP()
    {
        hp.SetCharacter(currentCharacter);
    }
}

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
    public HitDiceDeathSaves hitdicedeathsaves;
    public MoneyDisplay money;

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
        hitdicedeathsaves.SetCharacter(currentCharacter);
        money.SetCharacter(currentCharacter);
    }

    public void UpdateHP()
    {
        hp.SetCharacter(currentCharacter);
    }

    public void UpdateHitDieAndDeathSaves()
    {
        hitdicedeathsaves.SetCharacter(currentCharacter);
    }

    public void UpdateMoney()
    {
        money.SetCharacter(currentCharacter);
    }
}

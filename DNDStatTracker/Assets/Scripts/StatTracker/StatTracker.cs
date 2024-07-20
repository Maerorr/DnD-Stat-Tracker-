using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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
    public FeaturesAndTraits featuresAndTraits;

    public SpellDisplay spells;

    private List<IEditable> editableElements;

    private bool isEditMode = false;

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
        
        featuresAndTraits.SetCharacter(currentCharacter);
        
        spells.SetCharacter(currentCharacter);
        
        SaveCharacter();

        StartCoroutine(GetEditables());
    }

    IEnumerator GetEditables()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        editableElements = FindObjectOfType<Canvas>().gameObject.GetComponentsInChildren<IEditable>().ToList();
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

    public void UpdateProficiencies()
    {
        savesSpawner.UpdateSaves();
        proficienciesSpawner.UpdateSkillProficiencies();
    }

    public void SaveCharacter()
    {
        string characterJson = JsonConvert.SerializeObject(currentCharacter, Formatting.Indented);
        string filename =
            $"{currentCharacter.characterName}_{currentCharacter.characterClass.GetName()}_{currentCharacter.level}.json";
        System.IO.File.WriteAllText(Application.persistentDataPath + $"/{filename}", characterJson);
    }

    public void OnToggleEdit()
    {
        isEditMode ^= true;
        editableElements.ForEach(editable =>
        {
            if (editable is not null)
            {
                editable.ToggleEditMode(isEditMode);
            }
        });
    }
    
    /*public void UpdateFeatures()
    {
        featuresAndTraits.SetCharacter();
    }*/
}

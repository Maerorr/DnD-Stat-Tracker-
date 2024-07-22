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
    public Spells spellDatabase;

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
        LoadSpellDatabase();
    }

    IEnumerator GetEditables()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        editableElements = FindObjectOfType<Canvas>().gameObject.GetComponentsInChildren<IEditable>().ToList();
    }

    public void UpdateStats()
    {
        statsSpawner.UpdateStatEntries();
        UpdateProficiencies(); // update the mods
        UpdateACInitSpeed(); // dex can change AC and Initiative
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

    public void UpdateACInitSpeed()
    {
        achpspeed.SetCharacter(currentCharacter);
    }

    public void UpdateSpells()
    {
        spells.SetCharacter(currentCharacter);
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

    private void LoadSpellDatabase()
    {
        spellDatabase = new Spells();
        string basePath = Application.persistentDataPath;
        for (int i = 0; i < 9; i++)
        {
            string jsonPath = basePath + $"/SpellsDatabase/spell_level_{i}.json";
            string jsontext = System.IO.File.ReadAllText(jsonPath);
            Spell[] spells = JsonConvert.DeserializeObject<Spell[]>(jsontext);
            Dictionary<string, (Spell, bool)> spellsDict = new Dictionary<string, (Spell, bool)>();
            foreach (var spell in spells)
            {
                spellsDict.Add(spell.name, (spell, false));
            }

            if (i == 0)
            {
                spellDatabase.cantrips = spellsDict;
            }
            else
            {
                spellDatabase.spells[i - 1] = spellsDict;
            }
        }
    }
}

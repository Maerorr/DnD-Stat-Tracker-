using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellPicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject spellPickPrefab;
    [SerializeField] private GameObject firstChild;
    [SerializeField] private GameObject spellPickList;
    [SerializeField] private GameObject closeButton;
    private List<GameObject> spells;
    private Color initialColor;
    private Image img;

    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
        img = GetComponent<Image>();
        img.raycastTarget = false;
        initialColor = img.color;
        img.color = Color.clear;
        closeButton.SetActive(false);
        firstChild.SetActive(false);
        //spellPickList.SetActive(false);
    }

    public void SetCharacter(Character character)
    {
        c = character;
    }

    public void Show(int level)
    {
        closeButton.SetActive(true);
        firstChild.SetActive(true);
        //spellPickList.SetActive(true);
        img.color = initialColor;
        img.raycastTarget = true;
        var spellsFromDatabase = st.spellDatabase.GetSpellsOfLevelAndClass(level, c.characterClass);
        var cSpells = c.spellList.GetSpellsOfLevel(level);
        spellsFromDatabase.RemoveAll(spell => cSpells.ContainsKey(spell.Item1.name));

        foreach (Transform child in spellPickList.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var spell in spellsFromDatabase)
        {
            var obj = Instantiate(spellPickPrefab, spellPickList.transform);
            obj.GetComponent<SpellPickEntry>().SetSpellData(spell.Item1.name, spell.Item1.level, this);
        }
    }

    public void Hide()
    {
        img.raycastTarget = false;
        img.color = Color.clear;
        firstChild.SetActive(false);
        closeButton.SetActive(false);
        //spellPickList.SetActive(false);
    }

    public void OnAddSpell(string spellName, int spellLevel)
    {
        c.spellList.AddSpell(st.spellDatabase.GetSpellOfLevelByName(spellLevel, spellName), false);
        st.UpdateSpells();
        Hide();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
    }
}

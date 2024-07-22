using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmorHealthSpeed : MonoBehaviour, IEditable
{
    [SerializeField] private TextMeshProUGUI ac;
    [SerializeField] private TextMeshProUGUI initiative;
    [SerializeField] private TextMeshProUGUI speed;
    private Character c;
    private StatTracker st;

    [SerializeField] List<GameObject> editButtons;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
        editButtons.ForEach(button => button.SetActive(false));
    }

    public void SetCharacter(Character character)
    {
        c = character;

        ac.text = $"{c.GetTotalArmorClass()}";
        int init = c.GetTotalInitiative();
        string sign = init > 0 ? "+" : "";
        initiative.text = $"{sign}{init}";
        speed.text = $"{c.speed}ft.";
    }

    public void AddAC()
    {
        c.armorClass++;
        st.UpdateACInitSpeed();
    }

    public void SubAC()
    {
        c.armorClass--;
        st.UpdateACInitSpeed();
    }

    public void AddInitiative()
    {
        c.initiativeBonus++;
        st.UpdateACInitSpeed();
    }

    public void SubInitiative()
    {
        c.initiativeBonus--;
        st.UpdateACInitSpeed();
    }

    public void AddSpeed()
    {
        c.speed += 5;
        st.UpdateACInitSpeed();
    }

    public void SubSpeed()
    {
        c.speed -= 5;
        st.UpdateACInitSpeed();
    }
    
    public void ToggleEditMode(bool edit)
    {
        editButtons.ForEach(button => button.SetActive(edit));
    }
}

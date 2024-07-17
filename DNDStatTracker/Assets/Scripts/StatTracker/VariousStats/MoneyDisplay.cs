using System;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI copperValue;
    [SerializeField] private TextMeshProUGUI silverValue;
    [SerializeField] private TextMeshProUGUI electrumValue;
    [SerializeField] private TextMeshProUGUI goldValue;
    [SerializeField] private TextMeshProUGUI platinumValue;
    
    [SerializeField] private TMP_InputField copperInput;
    [SerializeField] private TMP_InputField silverInput;
    [SerializeField] private TMP_InputField electrumInput;
    [SerializeField] private TMP_InputField goldInput;
    [SerializeField] private TMP_InputField platinumInput;

    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacter(Character character)
    {
        c = character;
        copperValue.text = $"{c.money.money["Copper"]}";
        silverValue.text = $"{c.money.money["Silver"]}";
        electrumValue.text = $"{c.money.money["Electrum"]}";
        goldValue.text = $"{c.money.money["Gold"]}";
        platinumValue.text = $"{c.money.money["Platinum"]}";
    }

    public int ParseInput(String input)
    {
        if (input.Length == 0)
        {
            return 0;
        } 
        
        return int.Parse(input);
    }
    
    public void AddCopper()
    {
        c.money.money["Copper"] += ParseInput(copperInput.text);
        st.UpdateMoney();
        copperInput.text = "";
    }

    public void SubCopper()
    {
        int val = ParseInput(copperInput.text);
        if (val < c.money.money["Copper"])
        {
            c.money.money["Copper"] -= val;
            st.UpdateMoney();
        }
        copperInput.text = "";
    }
    
    public void AddSilver()
    {
        c.money.money["Silver"] += ParseInput(silverInput.text);
        st.UpdateMoney();
        silverInput.text = "";
    }

    public void SubSilver()
    {
        int val = ParseInput(silverInput.text);
        if (val < c.money.money["Silver"])
        {
            c.money.money["Silver"] -= val;
            st.UpdateMoney();
        }
        silverInput.text = "";
    }
    
    public void AddElectrum()
    {
        c.money.money["Electrum"] += ParseInput(electrumInput.text);
        st.UpdateMoney();
        electrumInput.text = "";
    }

    public void SubElectrum()
    {
        int val = ParseInput(electrumInput.text);
        if (val < c.money.money["Electrum"])
        {
            c.money.money["Electrum"] -= val;
            st.UpdateMoney();
        }
        electrumInput.text = "";
    }
    
    public void AddGold()
    {
        c.money.money["Gold"] += ParseInput(goldInput.text);
        st.UpdateMoney();
        goldInput.text = "";
    }

    public void SubGold()
    {
        int val = ParseInput(goldInput.text);
        if (val < c.money.money["Gold"])
        {
            c.money.money["Gold"] -= val;
            st.UpdateMoney();
        }
        goldInput.text = "";
    }
    
    public void AddPlatinum()
    {
        c.money.money["Platinum"] += ParseInput(platinumInput.text);
        st.UpdateMoney();
        platinumInput.text = "";
    }

    public void SubPlatinum()
    {
        int val = ParseInput(platinumInput.text);
        if (val > c.money.money["Platinum"])
        {
            c.money.money["Platinum"] -= val;
            st.UpdateMoney();
        }
        platinumInput.text = "";
    }
    
}

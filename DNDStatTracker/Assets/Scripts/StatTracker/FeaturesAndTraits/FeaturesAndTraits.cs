using System;
using TMPro;
using UnityEngine;

public class FeaturesAndTraits : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI featuresAndTraits;
    private Character c;
    private StatTracker st;

    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
    }

    public void SetCharacter(Character character)
    {
        c = character;
        featuresAndTraits.text = c.featuresAndTraits;
    }

    public void OnTextChanged(String s)
    {
        c.featuresAndTraits = s;
    }

}

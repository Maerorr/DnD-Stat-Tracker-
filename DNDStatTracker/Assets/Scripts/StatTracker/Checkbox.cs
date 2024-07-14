using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox : MonoBehaviour
{
    private bool active = false;
    [SerializeField] private Image activeCheck;
    [SerializeField] private GameObject nonEditGroup;
    [SerializeField] private GameObject editGroup;
    private Toggle toggle;

    private Color initialCheckColor;
    
    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        toggle.onValueChanged.AddListener(Toggle);
        editGroup.SetActive(false);
        active = false;
        initialCheckColor = activeCheck.color;
    }

    public void Toggle(bool val)
    {
        active = val;
        activeCheck.color = val ? Color.white : initialCheckColor;
    }

    public void SetActive(bool active)
    {
        this.active = active;
        toggle.isOn = active;
        activeCheck.color = active ? Color.white : initialCheckColor;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox : MonoBehaviour, IEditable
{
    private bool active = false;
    [SerializeField] private Image activeCheck;
    [SerializeField] private GameObject nonEditGroup;
    [SerializeField] private GameObject editGroup;
    public Toggle toggle;
    [SerializeField] private bool editable = true;
    [SerializeField] private bool editableOnly = false;

    private Color initialCheckColor;
    
    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        toggle.onValueChanged.AddListener(Toggle);
        if (editableOnly)
        {
            nonEditGroup.SetActive(false);
        }
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

    public void ToggleEditMode(bool edit)
    {
        if (!editable) return;
        editGroup.SetActive(edit);
        nonEditGroup.SetActive(!edit && !editableOnly);
    }
}

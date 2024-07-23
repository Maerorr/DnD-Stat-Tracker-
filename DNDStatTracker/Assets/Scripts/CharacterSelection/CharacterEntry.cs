using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterEntry : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Color defaultColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color clickColor;
    [SerializeField] private Image buttonImage;
    
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private Image characterSplashIcon;

    private string characterName;
    private string characterJsonPath;
    private Sprite splashImage;

    private StatTracker st;

    private bool isMouseInside;
    
    private void Start()
    {
        st = FindAnyObjectByType<StatTracker>();
        defaultColor = buttonImage.color;
    }

    public void SetCharacterData(string name, string jsonPath, Sprite image)
    {
        characterName = name;
        characterJsonPath = jsonPath;
        splashImage = image;

        characterNameText.text = characterName;
        if (image is not null)
        {
            characterSplashIcon.sprite = image;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseInside = true;
        buttonImage.color = hoverColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        st.LoadCharacter(characterJsonPath);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseInside = false;
        buttonImage.color = defaultColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isMouseInside)
        {
            buttonImage.color = clickColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMouseInside)
        {
            buttonImage.color = hoverColor;
        }
        else
        {
            buttonImage.color = defaultColor;
        }
    }
}

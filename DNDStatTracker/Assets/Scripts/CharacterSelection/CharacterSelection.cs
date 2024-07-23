using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject characterEntryPrefab;
    [SerializeField] private GameObject spawnRoot;

    private void Start()
    {
        LoadCharacters();
    }

    private void LoadCharacters()
    {
        foreach (Transform child in spawnRoot.transform)
        {
            Destroy(child.gameObject);
        }
        
        string path = Application.persistentDataPath + "/Characters";
        string imagesPath = Application.persistentDataPath + "/Images";
        
        string[] files = System.IO.Directory.GetFiles(path);

        foreach (string file in files)
        {
            Debug.Log(file);
            var entry = Instantiate(characterEntryPrefab, spawnRoot.transform);
            var charEntry = entry.GetComponent<CharacterEntry>();
            string fileName = file.Split('\\').Last().Replace("json", "png");
            Sprite sprite;
            try
            {
                byte[] rawImage = System.IO.File.ReadAllBytes(imagesPath + "/" + fileName);
                Texture2D tex = new Texture2D(1, 1);
                tex.LoadImage(rawImage);
                sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            }
            catch (Exception e)
            {
                sprite = null;
            }
            
            string characterName = fileName.Split('_').First();
            charEntry.SetCharacterData(characterName, file, sprite);
        }
    }
}

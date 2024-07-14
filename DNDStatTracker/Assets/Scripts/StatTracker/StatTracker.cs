using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    private Character currentCharacter;
    
    public StatsSpawner statsSpawner;
    public SavingThrowsSpawner savesSpawner;

    private void Start()
    {
        currentCharacter = Character.Default();
        
        statsSpawner.SpawnEntries(currentCharacter.stats);
        savesSpawner.SpawnEntries(currentCharacter.stats);
    }
}

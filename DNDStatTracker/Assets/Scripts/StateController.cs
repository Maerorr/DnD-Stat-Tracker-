using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject stats;

    public void ChangeToStats()
    {
        stats.SetActive(true);
        characterSelection.SetActive(false);
    }

    public void ChangeToCharacterSelection()
    {
        stats.SetActive(false);
        characterSelection.SetActive(true);
    }
}

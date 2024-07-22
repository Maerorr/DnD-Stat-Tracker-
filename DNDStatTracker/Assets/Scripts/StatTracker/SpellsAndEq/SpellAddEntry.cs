using UnityEngine;

public class SpellAddEntry : MonoBehaviour
{
    private int level;
    private SpellPicker picker;

    public void SetData(int level, SpellPicker picker)
    {
        this.level = level;
        this.picker = picker;
    }

    public void OnAddPressed()
    {
        picker.Show(level);
    }
}

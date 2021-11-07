using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPicker : MonoBehaviour
{
    [SerializeField] private List<Unit> availableUnits;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int currentId = 0;
    private Image unitSprite;

    private void Start()
    {
        currentId = 0;
        UpdateCharacterList();
        DisplayUnit(currentId);
    }

    private void DisplayUnit(int id)
    {
        this.GetComponentInChildren<Image>().sprite = sprites[currentId];
    }

    public void UpdateCharacterList()
    {
        availableUnits = GameManager.Instance.availablePlayerUnits;
        sprites = new Sprite[availableUnits.Count];

        int unitId = 0;
        foreach (Unit new_unit in availableUnits)
        {
            sprites[unitId] = (new_unit.GetComponentInChildren<SpriteRenderer>().sprite);
            unitId++;
        }

    }

    public void NextChoice()
    {
        if(currentId == availableUnits.Count) currentId = 0;
        else currentId++;
        DisplayUnit(currentId);
    }

    public void Back()
    {
        if (currentId == 0) currentId = availableUnits.Count;
        else currentId--;
        DisplayUnit(currentId);
    }

}

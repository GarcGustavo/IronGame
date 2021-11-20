using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPicker : MonoBehaviour
{
    [SerializeField] private List<Unit> availableUnits;
    //[SerializeField] private Sprite[] sprites;
    [SerializeField] private int currentId = 0;
    private Image unitSprite;


    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject ContentPanel;
    [SerializeField] public SpriteManager ListItemPrefab;
    [SerializeField] public Sprite placeHolderSprite;

    private void Start()
    {
        currentId = 0;
        UpdateCharacterList();
        DisplayUnit(currentId);
    }

    private void DisplayUnit(int id)
    {
        //this.GetComponentInChildren<Image>().sprite = sprites[currentId];


        foreach (Unit unit in availableUnits)
        {
            Unit unitSprite = Instantiate(unit, ContentPanel.transform) as Unit;
            unitSprite.gameObject.layer = 5;
            //SpriteManager displayUnit = Instantiate(ListItemPrefab, ContentPanel.transform) as SpriteManager;
            //displayUnit.unitSprite = new SpriteRenderer();
            //displayUnit.unitSprite = unitSprite.GetComponent<SpriteRenderer>();
            //SpriteManager listItem = new SpriteManager();
            //listItem = Instantiate(ListItemPrefab, ContentPanel.transform) as SpriteManager;
            //controller.Icon.sprite = unit.defaultSprite;
            //spriteM.Icon.sprite = unit.GetComponentInChildren<SpriteRenderer>().sprite;
            //controller.Icon.sprite = placeHolderSprite;
            SpriteRenderer spriteRenderer = unitSprite.gameObject.GetComponentInChildren<SpriteRenderer>();
            unitSprite.GetComponentInParent<Image>().sprite = spriteRenderer.sprite;
            //displayUnit.unitSprite = spriteRenderer;
            //displayUnit.unitSprite.sprite = spriteRenderer.sprite;
            //spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            //spriteM.Name.text = "Name"; //unit.defaultSprite;
            //spriteM.Description.text = "Description"; //unit.defaultSprite;
            unitSprite.transform.parent = ContentPanel.transform;
            //Place unit in-front of all other UI objects
            unitSprite.transform.position.Set(unitSprite.transform.position.x, unitSprite.transform.position.y, -5f);
            unitSprite.transform.localScale = Vector3.one * 275;
            //unitSprite.transform.localScale = Vector3.one;
        }
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
    /*
    public void NextChoice()
    {
        if(currentId == availableUnits.Count - 1) currentId = 0;
        else currentId++;
        DisplayUnit(currentId);
    }

    public void Back()
    {
        if (currentId == 0) currentId = availableUnits.Count;
        else currentId--;
        DisplayUnit(currentId);
    }
    */
    //TODO - Implement version of this list controller to manage scrolling sprites panel

    /*
    public Sprite[] AnimalImages;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    ArrayList Anmimals;

    void Start()
    {

        // 1. Get the data to be displayed
        Anmimals = new ArrayList(){
 new Animal(AnimalImages[0],
            "Cat",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0"),
 new Animal(AnimalImages[1],
            "Dog",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0"),
 new Animal(AnimalImages[2],
            "Fish",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0"),
 new Animal(AnimalImages[3],
            "Parrot",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0"),
 new Animal(AnimalImages[4],
            "Rabbit",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0"),
 new Animal(AnimalImages[5],
            "Snail",
            "Power\t:\t5\nAttack\t:\t5\nTame\t:\t10\nVenom\t:\t0")
 };

        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach (Animal animal in Anmimals)
        {
            GameObject newAnimal = Instantiate(ListItemPrefab) as GameObject;
            ListItemController controller = newAnimal.GetComponent();
            controller.Icon.sprite = animal.Icon;
            controller.Name.text = animal.Name;
            controller.Description.text = animal.Description;
            newAnimal.transform.parent = ContentPanel.transform;
            newAnimal.transform.localScale = Vector3.one;
        }
    }*/

}

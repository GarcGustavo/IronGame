using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton setup
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    //Managers
    public AudioManager audioManager;
    public UIManager uiManager;
    public InputManager inputManager;

    //Object Lists
    public List<Unit> playerUnits;
    public List<Unit> enemyUnits;
    public List<Consumable> playerConsumables;

    //Scene Objects
    public Camera mainCamera;
    public Spawner playerSpawner;
    public Spawner enemySpawner;

    //Scene Stats
    public int playerScore;
    public int playerHealth;
    public int playerActiveUnits = 0;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    public void StartRound()
    {
        //clear unit list from last round
        playerSpawner.ClearUnits();
        enemySpawner.ClearUnits();
        //give spawner unit list for current round
        playerSpawner.AddUnits(playerUnits);
        enemySpawner.AddUnits(enemyUnits);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerActiveUnits = playerSpawner.ActiveUnits();
    }
}

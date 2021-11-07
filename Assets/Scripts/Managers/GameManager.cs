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

    //Public flags
    public bool roundStarted = false;


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

    void Start()
    {
        EventsManager.current.onStartRound += StartRound;
        EventsManager.current.onStopRound += StopRound;
    }

    public void StartRound()
    {
        if (!roundStarted)
        {
            //clear unit list from last round
            playerSpawner.ClearUnits();
            enemySpawner.ClearUnits();
            //give spawner unit list for current round
            playerSpawner.AddUnits(playerUnits);
            enemySpawner.AddUnits(enemyUnits);
            roundStarted = true;
        }
    }

    public void StopRound()
    {
        if (roundStarted)
        {
            //clear unit list from last round
            playerSpawner.ClearUnits();
            enemySpawner.ClearUnits();
            roundStarted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerActiveUnits = playerSpawner.ActiveUnits();
    }
}

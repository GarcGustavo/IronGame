using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class EventsManager : MonoBehaviour
{

    /// <summary>
    /// ///////////////////////////////////////////////////////////////
    /// </summary>

    public UnityEvent unityEvent;
    //General Events
    public UnityEvent StartRoundEvent;
    public UnityEvent StopRoundEvent;

    public UnityEvent PauseEvent;
    public UnityEvent StartMainMenuEvent;

    //TODO add if statement to check if id == this.id in unit calling this, add id var to unit
    public UnityEvent<int> AddUnitEvent;
    public UnityEvent<int> AttackEvent;
    public UnityEvent<int> DamageEvent;
    public UnityEvent<int> HealEvent;

    //UI events
    public UnityEvent OpenItemsEvent;
    public UnityEvent OpenTeamEvent;

    void Start()
    {
        //Initialize each event
        if (unityEvent == null)
            unityEvent = new UnityEvent();

        unityEvent.AddListener(UnityTestEventAction);

        //Use in order to add event listeners to event in other functions:
        //current.unityEvent.AddListener(MethodToPerform);
    }

    void UnityTestEventAction()
    {
        //Use unityEvent.Invoke() to call function
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public static EventsManager current;

    //General Events
    public event Action onStartRound;
    public event Action onStopRound;

    public event Action onPause;
    public event Action onStartMainMenu;

    //TODO add if statement to check if id == this.id in unit calling this, add id var to unit
    public event Action<int> onAddUnit;
    public event Action<int> onAttack;
    public event Action<int> onDamage;
    public event Action<int> onHeal;

    //UI events
    public event Action onOpenItems;
    public event Action onOpenTeam;

    void Awake()
    {
        current = this;
    }

    public void StartRound()
    {
        if (onStartRound != null)
        {
            onStartRound();
        }
    }

    public void StopRound()
    {
        if (onStopRound != null)
        {
            onStopRound();
        }
    }

    public void Pause()
    {
        if (onPause != null)
        {
            onPause();
        }
    }

    public void StartMainMenu()
    {
        if (onStartMainMenu != null)
        {
            onStartMainMenu();
        }
    }

    public void OpenItems()
    {
        if (onOpenItems != null)
        {
            onOpenItems();
        }
    }

    public void OpenTeam()
    {
        if (onOpenTeam != null)
        {
            onOpenTeam();
        }
    }

    public void AddUnit(int id)
    {
        if (onAddUnit != null)
        {
            onAddUnit(id);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;

    //General Events
    public event Action onStartRound;
    public event Action onStopRound;

    public event Action onPause;
    public event Action onStartMainMenu;

    //TODO add if statement to check if id == this.id in unit calling this, add id var to unit
    public event Action<int> onAddUnit;
    public event Action<int> onDamageUnit;
    public event Action<int> onHealUnit;

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

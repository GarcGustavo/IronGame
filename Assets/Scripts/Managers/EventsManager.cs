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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class TeamMenu : MonoBehaviour
{
    public List<Unit> playerTeam;
    [SerializeField] private Vector3 startPos = new Vector3(459, 1157, 0);
    [SerializeField] private Vector3 endPos = new Vector3(459, 87, 0);
    [SerializeField] private Vector3 bounceStrength = new Vector3(0, 2, 0);
    [SerializeField] private float moveDuration = 1f;

    private bool isActive = false;

    private void Start()
    {
        EventsManager.current.onOpenTeam += ShowTeamMenu;
        transform.localPosition = startPos;
    }

    private void ShowTeamMenu()
    {
        if (!isActive)
        {
            transform.DOLocalMove(endPos, moveDuration).OnComplete(() => transform.DOShakePosition(.5f, bounceStrength, vibrato: 5, randomness: 1, snapping: false, fadeOut: true));
            isActive = true;
        }
        else
            HideTeamMenu();
    }

    private void HideTeamMenu()
    {
        transform.DOLocalMove(startPos, moveDuration).OnComplete(() => Debug.Log("Team menu hidden"));
        isActive = false;
    }

    public void AddUnit()
    {

    }

    public void RemoveUnit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

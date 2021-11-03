using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Text unitsRemaining;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        unitsRemaining.text = "Units Remaining: " + GameManager.Instance.playerActiveUnits.ToString();
    }
}

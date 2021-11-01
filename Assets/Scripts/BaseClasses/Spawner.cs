using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool canSpawn;

    public Queue<Unit> disabledUnits;

    [SerializeField]
    private Unit unit;
    [SerializeField]
    private float spawnCD;
    [SerializeField]
    private int amountToPool;

    // Start is called before the first frame update
    void Awake()
    {
        canSpawn = false;
        disabledUnits = new Queue<Unit>();
        //Instantiate pool of units
        for (int i = 0; i < amountToPool; i++)
        {
            Unit unitInstance = Instantiate(unit, transform);
            disabledUnits.Enqueue(unitInstance);
            DisableUnit(unitInstance);
        }
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) StartCoroutine(SpawnUnit());
    }

    private IEnumerator SpawnUnit()
    {
        canSpawn = false;

        Unit newUnit = disabledUnits.Dequeue();
        newUnit.gameObject.SetActive(true);
        newUnit.setTeam(this);
        newUnit.setState(Unit.state.Moving);
        newUnit.transform.position = transform.position;

        yield return new WaitForSeconds(spawnCD);
        canSpawn = true;
    }

    public void DisableUnit(Unit deadUnit)
    {
        disabledUnits.Enqueue(deadUnit);
        deadUnit.gameObject.SetActive(false);
    }
}

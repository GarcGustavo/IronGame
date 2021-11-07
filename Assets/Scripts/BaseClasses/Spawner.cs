using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool canSpawn;

    public Queue<Unit> disabledUnits;
    //public Queue<Unit> activeUnits;

    //[SerializeField]
    //private Unit unit;
    [SerializeField]
    private List<Unit> units;
    [SerializeField]
    private float spawnCD;
    [SerializeField]
    private int amountToPool;
    [SerializeField]
    private int maxUnits = 5;
    private int currentUnits;

    // Start is called before the first frame update
    void Awake()
    {
        canSpawn = false;
        disabledUnits = new Queue<Unit>();
        currentUnits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.roundStarted && canSpawn && currentUnits < maxUnits) StartCoroutine(SpawnUnit());
    }

    //Methods for managing units per round, each round requires player to set desired units for his team
    public void AddUnits(List<Unit> unitList)
    {
        //Instantiate pool of units
        for (int i = 0; i < amountToPool; i++)
        {
            //create x amount of pooling instances for units in list
            foreach (Unit unit in unitList)
            {
                Unit unitInstance = Instantiate(unit, transform);
                units.Add(unitInstance);
                currentUnits++;
                DisableUnit(unitInstance);
            }

            //Unit unitInstance = Instantiate(unit, transform);
            //disabledUnits.Enqueue(unitInstance);
            //DisableUnit(unitInstance);
        }
        canSpawn = true;
    }

    public void ClearUnits()
    {

        foreach (Unit unit in units)
        {
            DisableUnit(unit);
        }

        currentUnits = 0;
        canSpawn = false;

    }

    private IEnumerator SpawnUnit()
    {

        Unit newUnit = disabledUnits.Dequeue();

        newUnit.gameObject.SetActive(true);
        newUnit.setTeam(this);
        newUnit.setState(Unit.state.Moving);
        newUnit.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-1f, 1f), transform.position.z);

        canSpawn = false;
        currentUnits++;
        
        yield return new WaitForSeconds(spawnCD);
        canSpawn = true;
    }

    public void DisableUnit(Unit deadUnit)
    {
        disabledUnits.Enqueue(deadUnit);
        deadUnit.gameObject.SetActive(false);
        currentUnits--;
    }

    public int ActiveUnits()
    {
        return currentUnits;
    }
}

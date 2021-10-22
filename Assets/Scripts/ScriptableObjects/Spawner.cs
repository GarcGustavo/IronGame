using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnCD;
    public bool canSpawn;
    public List<Unit> unitList;
    // Start is called before the first frame update
    void Awake()
    {
        canSpawn = true;
        foreach (Unit unit in unitList)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) StartCoroutine(SpawnUnit());
    }

    private IEnumerator SpawnUnit()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCD);
        canSpawn = true;
    }
}

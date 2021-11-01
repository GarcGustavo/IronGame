using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Unit unit;
    private Vector3 direction;
    private Rigidbody2D rb;

    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void MoveUnit(Vector3 direction)
    {
        rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}

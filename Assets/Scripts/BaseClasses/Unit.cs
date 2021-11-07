using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UnitController))]

public class Unit : MonoBehaviour
{
    //Convert to interface after initial build

    [SerializeField]
    private Spawner teamBase;
    private Unit currentTarget;
    private UnitController controller;
    private Animator animator;
    private bool canAttack = true;

    public Rigidbody2D rb;

    //public int id;
    public float health;
    public float attack;
    public float defense;

    public float moveSpeed;
    public float attackSpeed;

    public state currentState;

    public enum state
    {
        Idle,
        Moving,
        Attacking,
        Death
    };

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<UnitController>();
        teamBase = GetComponentInParent<Spawner>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (health <= 0)
        {
            setState(state.Death);
        }

        if (currentState == state.Attacking && canAttack) StartCoroutine(Attack(currentTarget));
        if (currentState == state.Idle) Idle();
        if (currentState == state.Death) StartCoroutine(Die());

    }

    public void FixedUpdate()
    {
        if (currentState == state.Moving) MoveUnit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit")
        {
            if(collision.GetComponent<Unit>().teamBase != teamBase)
            {
                currentTarget = collision.GetComponent<Unit>();
                setState(state.Attacking);
            }
        }

        if (collision.tag == "Spawner")
        {
            if (collision.GetComponent<Spawner>() != this.teamBase)
            {
                //currentTarget = collision.GetComponent<Spawner>();
                setState(state.Death);
            }
        }
    }

    public void setTeam(Spawner teamSpawner) => teamBase = teamSpawner;

    public void setState(state unitState)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
        currentState = unitState;
    } 

    public void setAttack(float attk) => attack = attk;
    public void setAttackSpeed(float speed) => attack = speed;
    public void setSpeed(float speed) => moveSpeed = speed;
    public void setDefense(float def) => defense = def;


    public void Damage(float dmg)
    {
        health -= dmg;
        //damage animation
    } 

    public void Heal(float hp)
    {
        health += hp;
        //heal animation
    }

    public IEnumerator Die()
    {
        //Death Animation
        //disable and add to pool queue
        animator.SetBool("isDying", true);
        yield return new WaitForSeconds(1);
        teamBase.DisableUnit(this);
    }

    public void Idle()
    {
        animator.SetBool("isIdle", true);
        //Idle Animation
    }

    public IEnumerator Attack(Unit target)
    {
        //play attack animation
        canAttack = false;
        animator.SetBool("isAttacking", true);
        target.Damage(attack);
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    public void MoveUnit()
    {
        animator.SetBool("isMoving", true);
        //Modify to use nearest enemy as direction
        controller.MoveUnit(transform.right);
    }

    public void GetNearestEnemy()
    {
        //will return position of nearest enemy and cache it
        //will use this method to call controller.MoveUnit towards nearest enemy's direction
    }

}

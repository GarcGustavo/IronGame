using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UnitController))]

public class Unit : MonoBehaviour
{
    //Convert to interface after initial build

    private Spawner teamBase;
    private Unit currentTarget;
    private UnitController controller;
    private Animator animator;

    public Rigidbody2D rb;

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
        if (currentState == state.Attacking) Attack(currentTarget);
        if (currentState == state.Idle) Idle();
        if (currentState == state.Death) Die();
    }

    public void FixedUpdate()
    {
        if (currentState == state.Moving) MoveUnit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Unit>().teamBase != teamBase)
        {
            currentTarget = collision.GetComponent<Unit>();
            setState(state.Attacking);
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

    public void Die()
    {
        //Death Animation
        //disable and add to pool queue
        animator.SetBool("isDying", true);
        teamBase.DisableUnit(this);
    }

    public void Idle()
    {
        animator.SetBool("isIdle", true);
        //Idle Animation
    }

    public void Attack(Unit target)
    {
        //play attack animation
        animator.SetBool("isAttacking", true);
        target.Damage(attack);
    }

    public void MoveUnit()
    {
        animator.SetBool("isMoving", true);
        controller.MoveUnit(transform.right);
    }

}

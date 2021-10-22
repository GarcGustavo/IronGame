using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int team;
    private Unit currentTarget;

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
        //initialize current target to base or player/enemy empty unit object
    }

    public void Update()
    {
        if (currentState == state.Attacking) Attack(currentTarget);
        if (currentState == state.Idle) Idle();
        if (currentState == state.Death) Die();
    }

    public void FixedUpdate()
    {
        if (currentState == state.Moving) Move(currentTarget.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Unit>().team != team)
        {
            currentTarget = collision.GetComponent<Unit>();
            setState(state.Attacking);
        }
    }

    public void setTeam(int faction) => team = faction;
    public void setState(state unitState) => currentState = unitState;

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
    }

    public void Idle()
    {
        //Idle Animation
    }

    public void Move(Vector2 targetPosition)
    {
        //Play movement animation
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + targetPosition * moveSpeed * Time.fixedDeltaTime);
    }
    public void Attack(Unit target)
    {
        //play attack animation
        target.Damage(attack);
    }

}

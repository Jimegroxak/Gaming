using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    private int damage = 25;
    private float baseAttackTimer = 2.5f;

    private float attackTimer;

    private void Start() 
    {
        ResetAttackTimer();
    }

    public void Attack(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy == null)
        {
            Debug.LogError("ERROR: no script named enemy found on " + gameObject);
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;       
        }

        else
        {
            enemy.SetHealth(damage);
            ResetAttackTimer();
        }
        
    }

    public void ResetAttackTimer()
    {
        attackTimer = baseAttackTimer;
    }


}

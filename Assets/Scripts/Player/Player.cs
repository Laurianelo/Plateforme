using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerStats {


    public event Action rebornEvent; 

    public bool PlayerIsDead { get { return PV <= 0f; } }


	void Update () {
        PlayerFall();
        if (rebornEvent != null && PlayerIsDead)
        {
            rebornEvent();
        }
	}

    public void PlayerFall()
    {
        Vector3 _pos = Camera.main.WorldToViewportPoint(transform.position);

        if(_pos.y <= 0.0f)
        {
            PV = 0;
        }
    }

    public void ReceiveDamage(float damage)
    {
        PV -= damage;
    }

    public void Attack(EnemyFight enemy)
    {
        enemy.ReceiveDamage(Damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : EnemyStats {

    [SerializeField]
    private HealthBar healthBar;

    public bool IsAlive { get {return CurrentHeath > 0f;} }

    public void ReceiveDamage(float damage)
    {
        CurrentHeath -= damage;
        healthBar.SetHealth(CurrentHeath, MaxHeath);
        if(!IsAlive)
        {
            Destroy(gameObject);
        }
    }

	
}

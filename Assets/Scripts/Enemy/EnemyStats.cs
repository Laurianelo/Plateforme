using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float MaxHeath { get; set; }

    public float CurrentHeath { get; set; }
    
    public float Damage { get; set; }

    public EnemyStats()
    {
        MaxHeath = 250f;
        CurrentHeath = MaxHeath;
    }


}

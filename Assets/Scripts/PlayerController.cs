using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;

    public static PlayerController Instance { get { return instance; } }

    private float x;

    public float GetX { get { return x;} }

    private PlayerMotor motor;

    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start () {
        motor = GetComponent<PlayerMotor>();

	}
	
	// Update is called once per frame
	void Update () {

        //get value in the axis x and y 
        x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Jump");

        if(x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
         }

        if (x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }

        //get velocity
        Vector2 _velocity = new Vector2(x, _y);

        //apply velocity in playermotor
        motor.RunAndJump(_velocity);
    }
}

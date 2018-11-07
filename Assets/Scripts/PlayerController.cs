using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    private PlayerMotor motor;
	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Jump");

        Vector2 _velocity = new Vector2(_x, _y);

        Debug.Log("vecteur : " + _velocity);

        motor.RunAndJump(_velocity);
    }
}

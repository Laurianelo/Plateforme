using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim
{
    Idle,
    Run,
    Jump
}


public class AnimationController : MonoBehaviour {

    private Animator anim;
    private PlayerController player;
    private PlayerMotor playerMotor;
    private StateAnim state;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerMotor = GetComponent<PlayerMotor>();

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(player.GetX);
            
        bool run = player.GetX == 1 || player.GetX == -1;


        if(run && playerMotor.Grounded)
        {
            state = StateAnim.Run;
        }
        else if(!run && playerMotor.Grounded)
        {
            state = StateAnim.Idle;
        }
        else if(!playerMotor.Grounded)
        {
            state = StateAnim.Jump;
        }

        Animation();
		
	}


    private void Animation()
    {
        switch(state)
        {
            case StateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);
                break;

            case StateAnim.Run:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
                anim.SetBool("Ground", true);
                break;

            case StateAnim.Jump:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", false);
                break;
            




        }

    }
}

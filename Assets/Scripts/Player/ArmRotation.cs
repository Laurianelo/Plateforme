using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        float _roatZ = Mathf.Atan2(_mousePosition.y, _mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, _roatZ);

    }
}

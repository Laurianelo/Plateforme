using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

    [SerializeField] private GameObject[] paralaxGameObject;

    [SerializeField]
    private float[] speedParalax;

    private Camera cam;
    private Vector3 previousCamPos;

	void Start () {
        cam = Camera.main;
        previousCamPos = cam.transform.position;
	}
	
	// moove background
	void Update () {
		
       for(int i = 0 ; i<paralaxGameObject.Length; i++)
        {

            float _speed = (previousCamPos.x - cam.transform.position.x)  * speedParalax[i];
            Vector3 _newPositon = new Vector3(paralaxGameObject[i].transform.position.x + _speed, paralaxGameObject[i].transform.position.y, paralaxGameObject[i].transform.position.z);
            paralaxGameObject[i].transform.position = _newPositon;

        }

        previousCamPos = cam.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    [SerializeField]
    private float speed = 15;

	void Update () {
        transform.Translate(Vector3.right* Time.deltaTime*speed);
        Destroy(gameObject, 1);
	}
}

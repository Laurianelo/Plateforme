using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private float lenght = 0.1f;
    [SerializeField]
    private float shakeAmount = 0.1f;

    private void Awake()
    {
        if(mainCam == null)
        {
            mainCam = Camera.main;
        }

    }

    public void StartShake()
    {
        StartCoroutine(BeginShake());
    }


    private IEnumerator BeginShake()
    {
        float _lenghtCoroutine  = lenght;
        _lenghtCoroutine += Time.time;
        
        while(Time.time <= _lenghtCoroutine)
        {
            Vector3 _camPos = mainCam.transform.position;
            float _shakeX = Random.value * shakeAmount;
            float _shakeY = Random.value * shakeAmount;

            _camPos.x += _shakeX;
            _camPos.y += _shakeY;

            mainCam.transform.position = _camPos;

            yield return new WaitForEndOfFrame();

            mainCam.transform.localPosition = new Vector3(0, 0, 0);
        }

    }
}

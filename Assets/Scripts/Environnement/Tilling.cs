using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilling : MonoBehaviour
{
    private Transform[] sprites;
    private int leftIndex;
    private int rightIndex;
    private float viewZone; //recover the area of ​​view of camera

    // Use this for initialization
    void Start()
    {
        sprites = new Transform[transform.childCount];

        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = sprites.Length - 1;

    }

    // Update is called once per frame
    void Update()
    {
        viewZone = (Camera.main.orthographicSize * Screen.width) / Screen.height;

        //moove to right
        if (Camera.main.transform.position.x >= (sprites[rightIndex].position.x + sprites[rightIndex].GetComponent<SpriteRenderer>().bounds.size.x / 2) - viewZone)
        {
            sprites[leftIndex].transform.position = new Vector3(sprites[rightIndex].position.x + sprites[rightIndex].GetComponent<SpriteRenderer>().bounds.size.x, sprites[rightIndex].position.y, sprites[rightIndex].position.z);

            rightIndex = leftIndex;
            leftIndex++;

            if (leftIndex > sprites.Length - 1)
            {
                leftIndex = 0;
            }
        }

        //moove to left
        if (Camera.main.transform.position.x <= (sprites[leftIndex].position.x - sprites[leftIndex].GetComponent<SpriteRenderer>().bounds.size.x / 2) + viewZone)
        {
            sprites[rightIndex].transform.position = new Vector3(sprites[leftIndex].position.x - sprites[leftIndex].GetComponent<SpriteRenderer>().bounds.size.x, sprites[leftIndex].position.y, sprites[leftIndex].position.z);

            leftIndex = rightIndex;
            rightIndex--;

            if (rightIndex < 0)
            {
                rightIndex = sprites.Length -1;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSize : MonoBehaviour
{
    public float sizeIncreaseScalar = 1;
    private float startY;
    public GameObject groundFollower;

    void Start()
    {
        startY = groundFollower.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float changeInY = startY - groundFollower.transform.position.y;
        float change = (float) changeInY * sizeIncreaseScalar;

        if (changeInY != 0) {
            if (transform.localScale.x <= 0) {
                transform.localScale = new Vector3(transform.localScale.x - change, transform.localScale.y + change, transform.localScale.z + change);
            }   
            else {
                transform.localScale = new Vector3(transform.localScale.x + change, transform.localScale.y + change, transform.localScale.z + change);
            }
        }

        startY = groundFollower.transform.position.y;
        
    }
}
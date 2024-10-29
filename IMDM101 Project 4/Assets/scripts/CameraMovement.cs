using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float startPosY;
    public float yOffset;
    public GameObject player;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceY = (player.transform.position.y * followSpeed) + yOffset;

        transform.position = new Vector3(transform.position.x, startPosY + distanceY, transform.position.z);
        
    }
}

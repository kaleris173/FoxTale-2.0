using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform Target;
    public float minHeight, maxheight;
    public Transform farBg, midBg;
    private float lastXPos;
    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMoveX = transform.position.x - lastXPos;
        farBg.position = farBg.position + new Vector3(amountToMoveX, 0f,0f);
        midBg.position = midBg.position + new Vector3(amountToMoveX * .5f, 0f, 0f);
        lastXPos = transform.position.x;

        transform.position = new Vector3(Target.position.x, Mathf.Clamp(Target.position.y,minHeight,maxheight), transform.position.z);
 
    }
}

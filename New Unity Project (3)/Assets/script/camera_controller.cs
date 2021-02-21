using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform Target;
    public float minHeight, maxheight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x, Mathf.Clamp(Target.position.y,minHeight,maxheight), transform.position.z);
 
    }
}

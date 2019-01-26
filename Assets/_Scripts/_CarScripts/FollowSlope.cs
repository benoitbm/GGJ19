using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSlope : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, 10))
            print("There is something below the object!");
    }
}

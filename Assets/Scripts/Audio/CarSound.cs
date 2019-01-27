using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio_Wwise;

public class CarSound : MonoBehaviour
{
    bool playOnce = false;
    // Start is called before the first frame update
    Rigidbody ridgid;
    void Start()
    {
        ridgid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ridgid.velocity.magnitude > 0)
        {
            if (playOnce == true)
            {
                playOnce = false;
            }
            AudioMaster.Instance.PlaySound("Car_Start", gameObject);
        }
        else
        {
            if (playOnce == false)
            {
                AudioMaster.Instance.PlaySound("Car_Stop", gameObject);
                playOnce = true;
            }

        }

    }
}

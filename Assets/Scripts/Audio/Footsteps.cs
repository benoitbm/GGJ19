using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Audio_Wwise;

public class Footsteps : MonoBehaviour
{
    public float footStepSpeed = 0.5f;
    float timer = 0;
    bool playOnce = false;
    // Start is called before the first frame update
    RigidbodyFirstPersonController rigidbodyFirstPersonController;
    void Start()
    {
        rigidbodyFirstPersonController = GetComponent<RigidbodyFirstPersonController>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbodyFirstPersonController.Velocity.magnitude > 0 )
        {
            if(timer > footStepSpeed)
            {
                if (playOnce == true)
                {
                    playOnce = false;
                }
                AudioMaster.Instance.PlaySound("Movement_StepPlayer", gameObject);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
            
        }
        else
        {
            if (playOnce == false)
            {
                AudioMaster.Instance.PlaySound("Movement_StepPlayer_Stop", gameObject);
                playOnce = true;
            }
            
            timer = 0;
        }

    }
}

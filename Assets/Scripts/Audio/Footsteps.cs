using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Audio_Wwise;

public class Footsteps : MonoBehaviour
{
    public float footStepSpeed = 0.5f;
    float timerstep = 0;
    float timerLine = 0;
    bool playOnce = false;
    float lineFrequency = 120.0f;
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
            if(timerstep > footStepSpeed)
            {
                if (playOnce == true)
                {
                    playOnce = false;
                }
                AudioMaster.Instance.PlaySound("Movement_StepPlayer", gameObject);
                timerstep = 0;
            }
            else
            {
                timerstep += Time.deltaTime;
            }

            if(timerLine > lineFrequency)
            {
                timerLine = 0;
                AudioMaster.Instance.PlaySound("Wonder", gameObject);
            }
            else
            {
                timerLine += Time.deltaTime;

            }


            
        }
        else
        {
            if (playOnce == false)
            {
                AudioMaster.Instance.PlaySound("Movement_StepPlayer_Stop", gameObject);
                playOnce = true;
            }

            timerstep = 0;
        }

    }
}

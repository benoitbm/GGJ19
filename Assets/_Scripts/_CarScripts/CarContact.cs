using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContact : MonoBehaviour
{

    public bool carHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            carHit = true;
            Debug.Log("Contact");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            carHit = false;
            Debug.Log("Moved out");
        }
    }
}

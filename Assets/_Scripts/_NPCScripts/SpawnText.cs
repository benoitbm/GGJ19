using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        r.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponentInParent<Reaction>().contact != false)
        {
            r.enabled = true;
        }
        else
        {
            r.enabled = false;
        }
    }
}

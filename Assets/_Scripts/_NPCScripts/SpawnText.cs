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
        if (r)
            r.enabled = false;
        else
            Debug.Assert(false, "No renderer for this object !");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponentInParent<Reaction>().contact != false && r)
        {
            r.enabled = true;
        }
        else if (r)
        {
            r.enabled = false;
        }
    }
}

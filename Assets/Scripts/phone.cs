using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    bool isHeld = true;

    Rigidbody rb;
    BoxCollider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHeld)
        {
            m_Collider.enabled = false;
            rb.Sleep();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            m_Collider.enabled = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public bool Hold
    {
        get { return isHeld; }
        set { isHeld = Hold; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_UI : MonoBehaviour
{
    private bar currentBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterBar(bar newBar)
    {
        currentBar = newBar;
    }

    public void Drink()
    {
        if (currentBar)
        {
            currentBar.Drink();
        }
    }

    public void Leave()
    {
        if (currentBar)
        {
            currentBar.LeaveBar();
        }
    }
}

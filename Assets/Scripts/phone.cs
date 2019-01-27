using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    public enum phoneState
    {
        empty,
        bar1 = 1,
        bar2 = 2,
        bar3 = 3,
        bar4 = 4,
        barFull = 5
    }

    bool isHeld = true;

    Rigidbody rb;
    BoxCollider m_Collider;

    [SerializeField] float secondsPerBar = 12;
    [SerializeField] GameObject miniMap;
    [SerializeField] Material[] frontPhoneMat;
    [SerializeField] Renderer frontPhoneRender;
    float remainingBattery;
    float maximumBattery;
    phoneState batteryState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Collider = GetComponent<BoxCollider>();

        refillBattery();
        maximumBattery = (float)phoneState.barFull * secondsPerBar;
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

    private void LateUpdate()
    {
        remainingBattery -= Time.deltaTime;
        if (remainingBattery <= 0)
        {
            remainingBattery = 0;
            batteryState = phoneState.empty;
            miniMap.SetActive(false);
        }
        else
        {
            batteryState = (phoneState)Mathf.CeilToInt(remainingBattery / secondsPerBar);
            miniMap.SetActive(true);
        }
        frontPhoneRender.material = frontPhoneMat[(int)batteryState];
    }

    public bool Hold
    {
        get { return isHeld; }
        set { isHeld = Hold; }
    }

    public float Battery
    {
        get { return remainingBattery; }
    }

    public phoneState PhoneState
    {
        get { return batteryState; }
    }

    public void refillBattery(phoneState state = phoneState.barFull)
    {
        remainingBattery = (float)(state) * secondsPerBar;
    }
}

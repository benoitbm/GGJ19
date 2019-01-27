using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio_Wwise;
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

    public enum ePhonePlace
    {
        inPocket,
        inHand,
        zooming,
        dropped
    }

    bool isHeld = true;

    Rigidbody rb;
    BoxCollider m_Collider;

    [SerializeField] float secondsPerBar = 36;
    [SerializeField] GameObject miniMap;
    [SerializeField] Material[] frontPhoneMat;
    [SerializeField] Renderer frontPhoneRender;
    [SerializeField] float economyRateInPocket = 5.0f;
    float remainingBattery;
    float maximumBattery;
    phoneState batteryState;
    private bool playOnce = false;
    ePhonePlace phonePlace = ePhonePlace.inPocket;
    private bool m_InBar = false;
    public bool InBar
    {
        get { return m_InBar; }
        set { m_InBar = value; }
    }

    private bool m_playLostBatterySound = false;
    public bool playLostBatterySound
    {
        get { return m_playLostBatterySound; }
        set { m_playLostBatterySound = value; }
    public ePhonePlace PhonePlace
    {
        get { return phonePlace; }
        set { phonePlace = value; }
    }

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
        if (!m_InBar)
        {
            remainingBattery -= phonePlace == ePhonePlace.inPocket ? Time.deltaTime / economyRateInPocket : Time.deltaTime;
            if (remainingBattery <= 0)
            {
                remainingBattery = 0;
                batteryState = phoneState.empty;
                if (playOnce == false)
                {
                    m_playLostBatterySound = true;
                    playOnce = true;
                }
                    
                miniMap.SetActive(false);
            }
            else
            {
                playOnce = false;
                int previousBatterystate = (int)batteryState;
                batteryState = (phoneState)Mathf.CeilToInt(remainingBattery / secondsPerBar);
                if (previousBatterystate > (int)batteryState)
                {
                    m_playLostBatterySound = true;
                }
                miniMap.SetActive(true);
            }
            frontPhoneRender.material = frontPhoneMat[(int)batteryState];
            AudioMaster.Instance.SetRTPC("Battery_Life", remainingBattery);
        }
    }

    public bool Hold
    {
        get { return isHeld; }
        set { isHeld = value; }
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
        if (state >= phoneState.barFull)
            state = phoneState.barFull;

        batteryState = state;
        remainingBattery = (float)(batteryState) * secondsPerBar;
    }
}

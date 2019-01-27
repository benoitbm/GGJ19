using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController p_Player;
    private phone p_Phone;

    [SerializeField] GameObject m_UIBar;
    [SerializeField] Image m_UIBackground;

    [SerializeField] Vector2 alcoholRange = new Vector2(1.0f, 1.5f);
    [SerializeField] Vector2Int batteryRange = new Vector2Int(0, 2);
    [SerializeField] Vector2Int drinksRange = new Vector2Int(3, 5);
    private int drinksAllowed;
    private int drinksUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        drinksAllowed = Random.Range(drinksRange.x, drinksRange.y + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            p_Player = other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
            p_Phone = other.GetComponentInChildren<phone>();

            //TODO : Trigger dialog enter
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(fadeImage(false));

            //m_UIBar.SetActive(true);
            m_UIBar.GetComponent<bar_UI>().RegisterBar(this);
            //Release mouse too
        }
    }

    public void Drink()
    {
        p_Player.Drink(Random.Range(alcoholRange.x, alcoholRange.y));
        p_Phone.refillBattery((phone.phoneState)((int)p_Phone.PhoneState + Random.Range(batteryRange.x, batteryRange.y + 1)));
        ++drinksUsed;
        //TODO : Drink reaction

        if (--drinksAllowed <= 0)
            LeaveBar();
    }

    public void LeaveBar()
    {
        //TODO : Dialog leave bar (case remaining drinks allowed)
        m_UIBar.SetActive(false);
        StartCoroutine(fadeImage(true));
        //Recapture
    }

    IEnumerator fadeImage(bool fade)
    {
        p_Player.InBar = !fade;
        p_Phone.InBar = !fade;

        if (fade)
        {
            for (float i = 1.5f; i >= 0; i -= Time.deltaTime)
            {
                Color col = m_UIBackground.color;
                col.a = i;
                m_UIBackground.color = col;
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1.5f; i += Time.deltaTime)
            {
                Color col = m_UIBackground.color;
                col.a = i;
                m_UIBackground.color = col;
                yield return null;
            }
        }

        if (!fade)
            m_UIBar.SetActive(true);
        else
            Destroy(gameObject, 1f);
    }
}

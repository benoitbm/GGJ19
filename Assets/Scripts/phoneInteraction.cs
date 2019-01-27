using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio_Wwise;

public class phoneInteraction : MonoBehaviour
{
    [SerializeField] phone m_Phone;
    [SerializeField] Transform center;
    [SerializeField] Transform camera;
    [SerializeField] Transform inHandPos;
    [SerializeField] Vector3 originalPos;
    [SerializeField] const float LerpTime = 2f;
    float currentLerpTime;
    bool phoneInHand = false;
    bool stowingPhone = true;
    bool playOnece = false;
    // Start is called before the first frame update
    void Start()
    {
        currentLerpTime = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool zoomPhone = Input.GetKey(KeyCode.Mouse1) || Input.GetAxis("Phone") > .2f;
        bool cancelZoomPhone = !zoomPhone && (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetAxis("Phone") <= .2f);
        if (Input.GetButtonDown("TogglePhone") && !zoomPhone)
        {
            phoneInHand = !phoneInHand; //Toggling between in pocket/in hand

            if (!phoneInHand)
            {
                currentLerpTime = 0;
                stowingPhone = true;
                playOnece = false;
                AudioMaster.Instance.PlaySound("TakePhone_In", gameObject);
                m_Phone.PhonePlace = phone.ePhonePlace.inPocket;
            }
        }
        else if (phoneInHand)
        {
            if (zoomPhone)
            {
                if (stowingPhone)
                    currentLerpTime = 0;

                stowingPhone = false;
                m_Phone.transform.position = Vector3.Lerp(m_Phone.transform.position, center.position, currentLerpTime);
                m_Phone.transform.rotation = Quaternion.Lerp(m_Phone.transform.rotation, camera.rotation, currentLerpTime);

                m_Phone.PhonePlace = phone.ePhonePlace.zooming;
            }
            else if (cancelZoomPhone || stowingPhone)
            {
                if (!stowingPhone)
                    currentLerpTime = 0;

                stowingPhone = true;
                if(playOnece == false)
                {
                    AudioMaster.Instance.PlaySound("TakePhone_In", gameObject);
                    playOnece = true;
                }

                m_Phone.transform.position = Vector3.Lerp(m_Phone.transform.position, inHandPos.position, currentLerpTime);
                m_Phone.transform.rotation = Quaternion.Lerp(m_Phone.transform.rotation, inHandPos.rotation, currentLerpTime);

                m_Phone.PhonePlace = phone.ePhonePlace.inHand;
            }
        }
        else
        {
            m_Phone.transform.localPosition = Vector3.Lerp(m_Phone.transform.localPosition, originalPos, currentLerpTime);
            m_Phone.transform.localRotation.eulerAngles.Set(0, 0, 0);
            m_Phone.PhonePlace = phone.ePhonePlace.inPocket;
        }

        currentLerpTime += Time.deltaTime;
    }
}

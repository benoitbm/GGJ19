using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    [SerializeField] endUI uiEnd;

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
        if (other.tag == "Player")
        {
            var p_Player = other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
            p_Player.InBar = true;

            var p_Phone = other.GetComponentInChildren<phone>();
            p_Phone.InBar = true;

            uiEnd.TriggerEndGame(other.gameObject);
        }
    }
}

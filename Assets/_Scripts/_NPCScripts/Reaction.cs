using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    public bool contact = false; //Sends update to core behaviour
    public AudioClip surprise;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") //On collision with player
        {
            contact = true;
            PlaySound();
            Debug.Log("Contact");
            StartCoroutine(Delay()); //Wait for a second before moving on
            
        }
    }

    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(1);
        contact = false;
    }

    private void PlaySound()
    {
        source.PlayOneShot(surprise, 1.0f);
    }
}

﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Audio_Wwise
{ 
    public class AudioMaster : MonoBehaviour
    {
        protected static AudioMaster instance;
        public static AudioMaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType(typeof(AudioMaster)) as AudioMaster;

                    if (instance == null)
                    {
                        Debug.LogWarning("There is no singleton of type " + typeof(AudioMaster).ToString() +
                                           " in the scene! Please ensure there's always one before playing.");

                        Debug.LogWarning("Creating provisory " + typeof(AudioMaster).ToString() + "...");
                        instance = new GameObject(typeof(AudioMaster).ToString()).AddComponent<AudioMaster>();
                    }
                }

                return instance;
            }
            private set { instance = value; }
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        public void  PlaySound(string eventname, GameObject gameobject)
        {
            AkSoundEngine.PostEvent(eventname, gameObject);
        }
    }
}

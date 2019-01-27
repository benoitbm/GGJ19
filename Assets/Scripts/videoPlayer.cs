using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour
{
    VideoPlayer player;
    [SerializeField] VideoClip[] videos;
    int nbVideos;

    // Start is called before the first frame update
    void Start()
    {
        nbVideos = videos.GetLength(0);
        player = GetComponent<VideoPlayer>();
        player.clip = videos[Random.Range(0, nbVideos)];
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isPlaying)
        {
            player.clip = videos[Random.Range(0, nbVideos)];
            player.Play();
        }
    }
}

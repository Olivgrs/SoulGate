using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.5f, 1);
            audio.pitch = Random.Range(0.8f, 1);
            audio.Play();
        }
    }
}

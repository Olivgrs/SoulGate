using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageVolume : MonoBehaviour
{
    public static float volume = 1f;
    public AudioSource m_MyAudioSource;
    public UnityEngine.UI.Slider m_mySlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManageGlobalVolume()
    {
        m_mySlider.onValueChanged.AddListener((value) =>
        {
            volume = value;
            m_MyAudioSource.volume = value;
        });
    }
}

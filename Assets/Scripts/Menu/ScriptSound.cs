using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSound : MonoBehaviour
{
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

    public void changeSoundSlider()
    {

        m_mySlider.onValueChanged.AddListener((value) =>
        {
            m_MyAudioSource.volume = value;
        });
    }
}

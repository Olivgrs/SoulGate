using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public GameObject Canva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        Canva.SetActive(false);
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    public void OnClickSettings(GameObject settings)
    {
        settings.SetActive(true);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    public void OnClickCredit()
    {

    }

    public void Back(GameObject hide)
    {
        hide.SetActive(false);
    }
}

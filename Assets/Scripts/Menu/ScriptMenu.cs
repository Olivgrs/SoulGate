using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
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
        Debug.Log("AAAAAA");
        SceneManager.LoadScene("Game");
    }

    public void OnClickSettings(GameObject settings)
    {
        settings.SetActive(true);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickCredit()
    {

    }

    public void Back(GameObject hide)
    {
        hide.SetActive(false);
    }
}

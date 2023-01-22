using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScriptResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleInputData(int val)
    {
        int f = 0, s = 0;
        bool isChange = true;
        switch (val)
        {
            case 0:
                f = 1920;
                s = 1080;
                break;
            case 1:
                f = 1440;
                s = 900;
                break;
            case 2:
                f = 1366;
                s = 768;
                break;
            default:
                isChange = false;
                break;
        }
        if (isChange)
            Screen.SetResolution(f, s,FullScreenMode.FullScreenWindow);
    }
}

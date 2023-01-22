using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("/Item/Canvas/RawImage").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

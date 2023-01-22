using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Compass : MonoBehaviour
{
    private RectTransform arrow;
    private GameObject player;
    private GameObject quest;

    private void Start()
    {
        //GameObject.Find("/Item/Canvas/Arrow").SetActive(true);
        arrow = GameObject.Find("/Item/Canvas/Arrow").GetComponent<RectTransform>();
        player = GameObject.Find("/Player");
        quest = GameObject.FindGameObjectWithTag("Levier");

    }

    void Update()
    {
        Vector3 dir = quest.transform.position - player.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        arrow.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
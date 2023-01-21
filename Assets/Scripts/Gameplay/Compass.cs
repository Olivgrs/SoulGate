using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Compass : MonoBehaviour {
    public RectTransform arrow;
public GameObject player;
public GameObject quest;
 
void Update () {
Vector3 dir = quest.transform.position - player.transform.position;
float angle = Vector2.SignedAngle(Vector2.right, dir);
arrow.rotation = Quaternion.Euler(0, 0, angle);
}
}
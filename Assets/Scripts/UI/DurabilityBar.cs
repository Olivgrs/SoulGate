using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DurabilityBar : MonoBehaviour
{
    public Slider slider;
    public float decrementSpeed = 1.0f;
    public float decrementValue = 0f;
    public GameObject ennemy;
    public GameObject light;

    public void SetMaxDurability(int durability)
    {
        slider.maxValue = durability;
        slider.value = durability;
    }

    void Start()
    {
        StartCoroutine(DecrementSlider());
    }

    IEnumerator DecrementSlider()
    {
        while (slider.value > 0)
        {
            slider.value -= decrementValue;
            if (slider.value <= 0)
            {
                light.SetActive(false);
            }
            yield return new WaitForSeconds(decrementSpeed);
        }
    }
}

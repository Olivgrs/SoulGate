using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;

    protected virtual void initialize()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Start()
    {
        initialize();
    }


    protected virtual void pickUp(Collider2D other)
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i] == 0)
            {
                Debug.Log("Je suis la");
                Instantiate(effect, transform.position, Quaternion.identity);
                inventory.items[i] = 1;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            pickUp(other);
        }
        
    }
}

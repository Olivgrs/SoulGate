using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;

    public TextMeshProUGUI infoBulle;

    public enum TypeObject { Light, Compass, Map }
    public TypeObject typeObject;
    public PlayerMovement player;

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
        int index;
        //player.resetItems();
        switch (typeObject)
        {
            case TypeObject.Light:
                index = 0;
                player.asLight = true;
                player.text.text = "Lumière récupérée, appuyez sur 1 pour l'activée";
                break;

            case TypeObject.Compass:
                player.asCompass = true;
                index = 1;
                player.text.text = "Boussole récupérée, appuyez sur 2 pour l'activée";
                break;

            case TypeObject.Map:
                index = 2;
                player.asMap = true;
                player.text.text = "Map récupérée, appuyez sur 3 pour l'activée";
                break;

            default:
                index = -1;
                break;
        }

        Instantiate(effect, transform.position, Quaternion.identity);
        //inventory.items[index] = 1; // vérifie si il est déjà
        Instantiate(itemButton, inventory.slots[index].transform, false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            infoBulle.text = "Vous avez trouvé un objet. Il va désormais etre automatiquement utilisé";
            pickUp(other);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollections : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (transform.name)
        {
            case "Bag":
                if (other.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    PlayerController.Instance.Bag.SetActive(true);
                    PlayerController.Instance.hasBag = true;
                }
                break;
            case "CollectedYoyo":
                if (other.CompareTag("Player"))
                {
                    PlayerController.Instance.hasYoyo = true;
                    Destroy(gameObject);
                }
                break;
            // case "Breakfast":
            //     if (other.CompareTag("Player"))
            //     {
            //         Destroy(gameObject);
            //         Debug.Log("Breakfast collectec");
            //     }
            //     break;
        }
        
    }
    
}

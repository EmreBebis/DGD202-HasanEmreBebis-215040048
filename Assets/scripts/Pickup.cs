using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item = new Item("Item Name", 1);
    public AudioClip pickupSound;  // Ses klibini eklemek için bir deðiþken

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);

            // Ses klibini çal
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            Destroy(gameObject, pickupSound.length); // Oyun nesnesini ses çalýndýktan sonra yok et
        }
    }
}


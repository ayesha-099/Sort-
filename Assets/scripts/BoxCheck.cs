using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public GameObject itemSlot1;
    public GameObject itemSlot2;

    void Update()
    {

        // Check if both item slots have items
        if (itemSlot1.transform.childCount > 0 && itemSlot2.transform.childCount > 0)
        {
            Debug.Log("Checking items in slots...");

            // Get the items in both slots
            GameObject item1 = itemSlot1.transform.GetChild(0).gameObject;
            GameObject item2 = itemSlot2.transform.GetChild(0).gameObject;

            // Compare the names of the items
            if (item1.name == item2.name)
            {
                Debug.Log("Both slots have the same item. Destroying items and the box.");

                // Destroy both items
                Destroy(item1);
                Destroy(item2);

                // Optional: Destroy the box if required
               // Destroy(gameObject); // Destroy the box
            }
        }
    }
}

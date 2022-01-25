using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollector : MonoBehaviour
{
    private int cherrieCount = 0;
    private int strawberryCount = 0;
    private int bananaCount = 0;
    private int melonCount = 0;
    private int pineappleCount = 0;
    private int appleCount = 0;
    private int totalFruits = 0;
   [SerializeField] private Text countText;

    private enum CollectableItems
    {
       Cherry,
       Apple,
       Banana,
       Melon,
       Orenge,
       Pineapple,
       Strawberry

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
           

            
             if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Cherry)))
            {
                cherrieCount++;
                Debug.Log(cherrieCount);
            }
            else if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Strawberry))) {
                strawberryCount++;
                Debug.Log(strawberryCount);
            }

            else if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Banana))) {
                bananaCount++;
                Debug.Log(bananaCount);
            }
            else if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Melon))) {
                melonCount++;
                Debug.Log(melonCount);
            }
            else if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Pineapple))) {
                pineappleCount++;
                Debug.Log(pineappleCount);
            }
            else if (collision.gameObject.CompareTag(Enum.GetName(typeof(CollectableItems), CollectableItems.Apple))) {
                appleCount++;
                Debug.Log (appleCount); 

            }
            totalFruits = cherrieCount + strawberryCount + bananaCount + melonCount + pineappleCount + appleCount;
            countText.text = "Fruites: " + totalFruits;

            Destroy(collision.gameObject);
        }
        
        
    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;


public class PickUpItem : MonoBehaviour
{
    [SerializeField] private TMP_Text messageField;

    public List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    [SerializeField] private Image itemImageHolder;

    public static event Action<Color> OnUseItem; 
    void Start()
    {
      
    }




    void Update()
    {
        CycleItems();
        UseItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUp(other.gameObject);
        }
    }

    public void PickUp(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);

        items.Add(color);
        activeItemIndex = items.Count - 1;
        UpdateItemImage();
    }

    public void CycleItems() 
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                activeItemIndex = (activeItemIndex + 1) % items.Count;
                UpdateItemImage();
            }
            else
            {
                ResetItemImage();
            }
        }
    }

    public void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && activeItemIndex != -1 && items.Count > 0)
        {
            Color usedItem = items[activeItemIndex];

            if (items.Count > 0 && activeItemIndex != -1)
            {
                if (usedItem == Color.blue)
                {
                   OnUseItem?.Invoke(usedItem);

                }
                else if (usedItem == Color.red)
                {
                    OnUseItem?.Invoke(usedItem);

                }
                else if (usedItem == Color.green)
                {
                    OnUseItem?.Invoke(usedItem);

                }

            }
           
            items.RemoveAt(activeItemIndex);

            activeItemIndex = items.Count > 0 ? Mathf.Min(activeItemIndex, items.Count - 1) : -1; //ga dit even uitzoeken ternary operators

            if (activeItemIndex != -1)
            {
                UpdateItemImage();
            }
            else {
                ResetItemImage();
            }
           



           

           
            
        }
        //return Color.clear;
      }

    private void UpdateItemImage()
    {
        if (activeItemIndex != -1)
        {
            itemImageHolder.color = items[activeItemIndex];
            itemImageHolder.enabled = true;
        }
    }

    private void ResetItemImage()
    {
        itemImageHolder.color = Color.white;
        itemImageHolder.enabled = false;
        activeItemIndex = -1;
    }

    private void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        messageField.text = message;
        yield return new WaitForSeconds(2);
        messageField.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PickUpItem : MonoBehaviour
{
    public List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    [SerializeField] private Image itemImageHolder;
    void Start()
    {
        
    }

    
    void Update()
    {

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

    public Color UseItem()
    {
        if (activeItemIndex != -1 && items.Count > 0)
        {
            Color usedItem = items[activeItemIndex];
            items.RemoveAt(activeItemIndex);
            activeItemIndex = items.Count > 0 ? Mathf.Min(activeItemIndex, items.Count - 1) : -1;
            UpdateItemImage();
            return usedItem;
        }
        return Color.clear;
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
}

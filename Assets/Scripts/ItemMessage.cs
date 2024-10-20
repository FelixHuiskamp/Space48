using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMessage : MonoBehaviour
{
    [SerializeField] private UI uiManager;
    [SerializeField] private PickUpItem itemManager;

    private void UseItem()
    {
        Color usedItem = itemManager.UseItem();

        if (usedItem == Color.blue)
        {
            uiManager.ShowMessage(" + Move Speed");
            moveSpeed += 5;
        }
        else if (usedItem == Color.red)
        {
            uiManager.ShowMessage(" + Fire Rate");
            cooldownTime -= 0.1f;
        }
        else if (usedItem == Color.green)
        {
            uiManager.ShowMessage(" + Rotation Speed");
            rotationSpeed += 10;
        }
    }


}

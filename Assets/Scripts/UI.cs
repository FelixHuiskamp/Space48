using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;

    void Start()
    {
        PickUpItem.OnUseItem += DisplayPowerup;
        DisplayIntroduction();
    }
   

    private void DisplayIntroduction()
    {

            StartCoroutine(DisplayMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'. \n Use pickups with 'E'."));

    }

    public void ShowMessage(string message)
    {
        StartCoroutine(DisplayMessage(message));
    }

    private IEnumerator DisplayMessage(string message)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
    private void DisplayPowerup(Color pColor) {

        
        if (pColor == Color.blue)
        {
            ShowMessage("+ Movement speed");
        }
        else if (pColor == Color.green)
        {
            ShowMessage("+ Rotation speed");
        }
        else if (pColor == Color.red) 
        {
            
            ShowMessage("- Cooldown time");        
        }
    } 

}

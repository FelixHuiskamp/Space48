using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float cooldownTime = 1f;

    [SerializeField] private UI uiManager;
    [SerializeField] private PickUpItem itemManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager.ShowIntroduction();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        MoveShipForward();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            itemManager.CycleItems();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }

    private void MoveShipForward()
    {
        
        float moveDirection = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        
        float rotationDirection = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemManager.PickUp(other.gameObject);
        }
    }
}

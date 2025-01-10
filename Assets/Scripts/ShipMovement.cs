using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;
using UnityEngine.EventSystems;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rotationSpeed = 100f;

    [SerializeField] private float speedPowerupIncrease = 10f;
    [SerializeField] private float rotationSpeedPowerupIncrease = 150f;
    private void Start()
    {
        PickUpItem.OnUseItem += PowerUp;
    }
    public void Move(float moveDirection, float rotationDirection)
    {
        

        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime); 
    }
    private void Update()
    {
        Move(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
    }

    private void PowerUp(Color pColor)
    {
        if (pColor == Color.blue)
        {
            moveSpeed += speedPowerupIncrease;
        }

        if (pColor == Color.green) 
        {
            rotationSpeed += rotationSpeedPowerupIncrease;
        }
    }

}

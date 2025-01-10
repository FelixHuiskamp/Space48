using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldownTime = 3f;

    [SerializeField] private float cooldownTimeDecrease = 1f;
    private float cooldownCounter = 3f;
    void Start()
    {
        PickUpItem.OnUseItem += PowerUp;
    }

    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }


    }

    private void PowerUp(Color pColor)
    {
        if (pColor == Color.red)
        {
            cooldownTime -= cooldownTimeDecrease;
        }
    }
}

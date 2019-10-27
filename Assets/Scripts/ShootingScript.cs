using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public IWeapon[] weapons;

    [SerializeField]
    private int currentWeapon;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            weapons[currentWeapon].Shoot();
        }
    }
}

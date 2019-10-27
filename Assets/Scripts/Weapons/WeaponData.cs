using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 52)]
public class WeaponData : ScriptableObject
{
    public Sprite sprite;
    public float damage;
    public float maxAmmo;
}

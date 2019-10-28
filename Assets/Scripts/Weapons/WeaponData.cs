using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 52)]
public class WeaponData : ScriptableObject
{
    public Sprite sprite;
    public string tag;
    public float damage;
    public int maxAmmo;
    public float shootTimer;
    public float scatter;
    public float bulletSpeed;
    public float bulletLifeTime;
}

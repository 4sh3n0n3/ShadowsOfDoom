using System;
using UnityEngine;

[Serializable]
public abstract class AbstractWeapon : MonoBehaviour
{
    public abstract int Ammo { get; }
    public abstract Sprite Sprite { get; }
    public abstract string WeaponTag { get; }

    public abstract void Shoot(Vector3 direction);
    public abstract void Restore();
    
}

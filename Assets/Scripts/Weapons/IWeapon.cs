using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot();
    void Restore();
    int Ammo { get; }
    Sprite Sprite { get; }
}

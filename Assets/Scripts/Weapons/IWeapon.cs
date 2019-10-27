using UnityEngine;

public interface IWeapon
{
    void Shoot();
    void Restore();
    int Ammo { get; }
    Sprite Sprite { get; }
    GameObject BulletPrefab { get; set; }
    string WeaponTag { get; }
    Camera Camera { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour, IWeapon
{
    public int Ammo => _currentAmmo;
    public Sprite Sprite => data.sprite;
    public GameObject BulletPrefab { get; set; }
    public string WeaponTag => data.tag;
    public Camera Camera { get; set; }

    public ShootingScript shooter;

    [SerializeField]
    private WeaponData data;

    private int _currentAmmo;
    private float _shootTimer;
    private Vector3 _mousePos;

    private void Start()
    {
        _currentAmmo = data.maxAmmo;
        shooter.AddNewWeapon(this);
    }

    private void Update()
    {
        if (_shootTimer > 0)
            _shootTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_shootTimer <= 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.damage = data.damage;
            bulletScript.speed = data.bulletSpeed;
            
            _mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
            bullet.transform.up = _mousePos - transform.position;
            bullet.transform.Rotate(new Vector3(0, 0, Random.Range(0, data.scatter)));
            _shootTimer = data.shootTimer;
        }
    }

    public void Restore()
    {
        _currentAmmo = data.maxAmmo;
    }
}

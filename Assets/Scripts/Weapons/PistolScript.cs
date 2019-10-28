using UnityEngine;

public class PistolScript : AbstractWeapon
{
    public override int Ammo => _currentAmmo;
    public override Sprite Sprite => data.sprite;
    public override string WeaponTag => data.tag;

    [SerializeField] 
    private GameObject bulletPrefab;

    [SerializeField]
    private WeaponData data;

    private int _currentAmmo;
    private float _shootTimer;
    private Vector3 _mousePos;

    private void Start()
    {
        _currentAmmo = data.maxAmmo;
    }

    private void Update()
    {
        if (_shootTimer > 0)
            _shootTimer -= Time.deltaTime;
    }

    public override void Shoot(Vector3 direction)
    {
        if (_shootTimer > 0)
            return;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.damage = data.damage;
        bulletScript.speed = data.bulletSpeed;
        bulletScript.lifeTime = data.bulletLifeTime;
            
        bullet.transform.up = direction;
        bullet.transform.Rotate(new Vector3(0, 0, Random.Range(0, data.scatter) - data.scatter / 2));
        bulletScript.StartMove();
        _shootTimer = data.shootTimer;
    }

    public override void Restore()
    {
        _currentAmmo = data.maxAmmo;
    }
}
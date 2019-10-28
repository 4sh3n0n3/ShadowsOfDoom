using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    
    [SerializeField]
    private int currentWeapon;

    [SerializeField]
    private AbstractWeapon[] weapons;

    private Vector3 _mousePos;

    private void Start()
    {
        UIController.Instance.UpdateWeaponImage(weapons[currentWeapon].Sprite);
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
            weapons[currentWeapon].Shoot(_mousePos - transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Q))
            ChangeWeapon(0);
        if (Input.GetKeyDown(KeyCode.E))
            ChangeWeapon(1);
    }

    private void ChangeWeapon(int weaponId)
    {
        if (weaponId < 0 || weaponId >= weapons.Length)
            return;
        
        currentWeapon = weaponId;
        UIController.Instance.UpdateWeaponImage(weapons[currentWeapon].Sprite);
    }

    public void RestoreAmmo(string weaponTag)
    {
        foreach (var w in weapons)
        {
            if (w.WeaponTag != weaponTag)
                continue;
            
            w.Restore();
            break;
        }
    }
}

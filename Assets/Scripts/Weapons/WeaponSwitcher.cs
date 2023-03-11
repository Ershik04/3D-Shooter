using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    private int _currentWeapon = 0;

    private void Start()
    {
        SetWeaponActive();
    }

    private void Update()
    {
        int previosWeapon = _currentWeapon;
        ProccesKeyInput();
        ProccesScrollWheel();
        if(previosWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if(weaponIndex == _currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void ProccesKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _currentWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _currentWeapon = 4;
        }
    }

    private void ProccesScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(_currentWeapon >= transform.childCount - 1)
            {
                _currentWeapon = 0;
            }
            else
            {
                _currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentWeapon <= 0)
            {
                _currentWeapon = transform.childCount - 1;
            }
            else
            {
                _currentWeapon--;
            }
        }
    }
}

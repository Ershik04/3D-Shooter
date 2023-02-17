using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera;
    [SerializeField]
    private float _range;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private ParticleSystem _particleSystem;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            ShootEffect();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy._isProvoked = true;
            if (target == null)
            {
                return;
            }
            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void ShootEffect()
    {
        _particleSystem.Play();
    }
}

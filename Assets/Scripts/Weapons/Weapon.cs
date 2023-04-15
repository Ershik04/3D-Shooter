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
    [SerializeField]
    private AMMO _ammoSlot;
    [SerializeField]
    private bool _canShoot = true;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void ProcessRaycasting()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, _range))
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
        }*/
        var point = new Vector3(_playerCamera.pixelWidth/2, _playerCamera.pixelHeight / 2, 0);
        var ray = _playerCamera.ScreenPointToRay(point);
        if (Physics.Raycast(ray, out var hit, _range))
        {
            Debug.Log(hit.transform.name);
            var objectHit = hit.transform.GetComponent<EnemyHealth>();
            /*Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy._isProvoked = true;*/
            if (objectHit != null)
            {
                objectHit.TakeDamage(_damage);
            }
            var objectHit2 = hit.transform.GetComponent<BossHealth>();
            if (objectHit2 != null)
            {
                objectHit2.BossTakeDamage(_damage);
            }
        }
    }

    IEnumerator Shoot()
    {
        if (_ammoSlot.GetCurentAMMO() > 0)
        {
            ShootEffect();
            ProcessRaycasting();
            _ammoSlot.ReduceCurrentAMMO();
            _canShoot = false;
        }
        yield return new WaitForSeconds(0.1f);
        _canShoot = true;
    }

    private void ShootEffect()
    {
        _particleSystem.Play();
    }
}

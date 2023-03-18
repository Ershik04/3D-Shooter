using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMMOPickUp : MonoBehaviour
{
    [SerializeField]
    private AMMO _ammo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _ammo = other.GetComponentInChildren<AMMO>();
            Debug.Log("Получены патроны");
            _ammo.IncraceCurrentAMMO();
            Destroy(gameObject);
        }
    }
}

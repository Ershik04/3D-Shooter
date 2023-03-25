using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.GetComponent<Player>();
            Debug.Log("Получена аптечка");
            _player.Heal(_health);
            Destroy(gameObject);
        }
    }
}

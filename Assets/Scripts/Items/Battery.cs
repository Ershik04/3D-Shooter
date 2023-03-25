using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private Flashlight _flashlight;
    [SerializeField]
    private float _addIntensity;
    [SerializeField]
    private float _restoreAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _flashlight = other.GetComponentInChildren<Flashlight>();
            Debug.Log("Получена батарейка");
            _flashlight.AddLightIntensity(_addIntensity);
            _flashlight.RestoreLightAngle(_restoreAngle);
            Destroy(gameObject);
        }
    }
}

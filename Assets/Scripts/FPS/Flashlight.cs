using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private float _lightAngleDecay;
    [SerializeField]
    private float _lightIntensityDecay;
    [SerializeField]
    private float _minLightAngle;
    private Light _flashlight;

    private void Start()
    {
        _flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    private void DecreaseLightIntensity()
    {
        _flashlight.intensity -= Time.deltaTime * _lightIntensityDecay;
    }

    private void DecreaseLightAngle()
    {
        if (_flashlight.spotAngle <= _minLightAngle)
        {
            return;
        } 
        else
        {
            _flashlight.spotAngle -= Time.deltaTime * _lightAngleDecay;
        }
    }

    public void AddLightIntensity(float indensityAmount)
    {
        _flashlight.intensity += indensityAmount;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        _flashlight.spotAngle = restoreAngle;
    }
}

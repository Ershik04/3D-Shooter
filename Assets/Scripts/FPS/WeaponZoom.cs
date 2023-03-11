using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    private bool _isEnable = false;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private int _basicFOV;
    [SerializeField]
    private int _FOV;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_isEnable == false)
            {
                _isEnable = true;
                _camera.fieldOfView = _FOV;
            } 
            else
            {
                _isEnable = false;
                _camera.fieldOfView = _basicFOV;
            }
        }
    }
}

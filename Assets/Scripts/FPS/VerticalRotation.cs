using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour
{
    [SerializeField]
    private float _sensitivityVer;
    private float _minVer = -45.0f;
    private float _maxVer = 45.0f;
    private float _rotationX;

    void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVer;
        _rotationX = Mathf.Clamp(_rotationX, _minVer, _maxVer);
        var rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}

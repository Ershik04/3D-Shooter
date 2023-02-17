using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour
{
    [SerializeField]
    private float _sensitivityHor;

    void Start()
    {
        
    }

    private void Update()
    {
        float horInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, horInput * _sensitivityHor, 0);
    }
}

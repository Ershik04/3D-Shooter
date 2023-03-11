using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTestScript : MonoBehaviour
{
    [SerializeField]
    private float _jumpSpeed;
    private Rigidbody _rb;
    [SerializeField]
    private bool _isGround;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGround = false;
    }
}

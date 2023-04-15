using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _isGround;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity = -9.81f;
    [SerializeField]
    private float _jumpHeigt;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _isGround = _controller.isGrounded;
        if (_isGround && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * _speed);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeigt * -3.0f * _gravity);
        }
        _playerVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity = -9.81f;
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * _speed;
        var deltaZ = Input.GetAxis("Vertical") * _speed;
        var motion = new Vector3(deltaX, 0, deltaZ);
        motion = Vector3.ClampMagnitude(motion, _speed);
        motion.y = _gravity;
        motion *= Time.deltaTime;
        motion = transform.TransformDirection(motion);
        _controller.Move(motion);
    }
}

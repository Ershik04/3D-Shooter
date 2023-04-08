using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private DirectionalLightRotation _directionalLightRotation;
    [SerializeField]
    private int _days;
    [SerializeField]
    private float _timeToOpen;
    private float _openTime;
    [SerializeField]
    private float speed;

    private void Update()
    {
        if (_directionalLightRotation.Days >= _days)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        while (_openTime < _timeToOpen)
        {
            _openTime += Time.deltaTime;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}

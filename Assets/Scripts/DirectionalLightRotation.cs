using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightRotation : MonoBehaviour
{
    [SerializeField]
    private float _secondsInDay;
    [SerializeField]
    private float _dayTime;
    [SerializeField]
    private int _days;
    public int Days => _days;

    private void Start()
    {
        _dayTime = 0;
    }

    private void Update()
    {
        _dayTime += Time.deltaTime / _secondsInDay;
        transform.localRotation = Quaternion.Euler((_dayTime * 360) - 90, 170, 0);
        if (_dayTime >= 1)
        {
            _dayTime = 0;
            _days += 1;
        }
    }
}

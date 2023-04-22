using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float _minPosition;
    [SerializeField]
    private float _maxPosition;
    [SerializeField]
    private Transform _spawnpoint;
    [SerializeField]
    private GameObject _template;
    [SerializeField]
    private int _minEnemiesNumber;
    [SerializeField]
    private int _maxEnemiesNumber;
    [SerializeField]
    private float _offset;
    [SerializeField]
    private float _maxTimer;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private DirectionalLightRotation _dayCounter;

    private void Start()
    {
        _timer = _maxTimer;
        SpawnEnemies();
    }

    private void Update()
    {
        _timer -= Time.deltaTime * _dayCounter.Days;
        if(_timer <= 0)
        {
            SpawnEnemies();
            _timer = _maxTimer;
        }
    }

    private void SpawnEnemies()
    {
        int numberItems = Random.Range(_minEnemiesNumber, _maxEnemiesNumber);
        for (int i = 0; i < numberItems; i++)
        {
            float _xPosition = Random.Range(_minPosition, _maxPosition);
            float _zPosition = Random.Range(_minPosition, _maxPosition);
            Vector3 generationPosition = new Vector3(_xPosition, _spawnpoint.position.y + _offset, _zPosition);
            Instantiate(_template, generationPosition, _spawnpoint.rotation, _spawnpoint);
        }
    }
}

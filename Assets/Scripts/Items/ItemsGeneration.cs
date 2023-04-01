using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGeneration : MonoBehaviour
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
    private int _minItemsNumber;
    [SerializeField]
    private int _maxItemsNumber;
    [SerializeField]
    private float _offset;

    private void Start()
    {
        GenerateItem();
    }

    private void GenerateItem()
    {
        int numberItems = Random.Range(_minItemsNumber, _maxItemsNumber);
        for (int i = 0; i < numberItems; i++)
        {
            float _xPosition = Random.Range(_minPosition, _maxPosition);
            float _zPosition = Random.Range(_minPosition, _maxPosition);
            Vector3 generationPosition = new Vector3(_xPosition, _spawnpoint.position.y + _offset, _zPosition);
            Instantiate(_template, generationPosition, _spawnpoint.rotation, _spawnpoint);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerHealt;
    [SerializeField]
    private GameOverUI _ui;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        _playerHealt -= damage;
        if(_playerHealt <= 0)
        {
            Debug.Log("���� ��������");
            _ui.StopGame();
            _playerHealt = 100;
        }
    }
}

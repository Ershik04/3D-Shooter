using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerHealth;
    public float PlayerHealth => _playerHealth;
    [SerializeField]
    private GameOverUI _ui;
    [SerializeField]
    private float _maxHealth = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        _playerHealth -= damage;
        if(_playerHealth <= 0)
        {
            Debug.Log("Игра окончена");
            _ui.StopGame();
            _playerHealth = 100;
        }
    }

    public void Heal(float health)
    {
        _playerHealth += health;
        if (_playerHealth > _maxHealth)
        {
            _playerHealth = _maxHealth;
        }
    }
}

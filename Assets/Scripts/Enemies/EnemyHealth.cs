using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Enemy _enemy;
    [SerializeField]
    private bool _isDead;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0 && _isDead == false)
        {
            _isDead = true;
            _enemy._canAttack = false;
            GetComponent<Animator>().SetTrigger("Fall");
            Destroy(gameObject, 3);
        }
    }
}

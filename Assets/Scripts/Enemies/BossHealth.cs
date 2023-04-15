using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Boss _enemy;
    [SerializeField]
    private bool _isDead;
    [SerializeField]
    private GameObject _winPanel;

    public void BossTakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0 && _isDead == false)
        {
            _isDead = true;
            _enemy._canAttack = false;
            GetComponent<Animator>().SetTrigger("Fall");
            Destroy(gameObject, 3);
            _winPanel.SetActive(true);
        }
    }
}

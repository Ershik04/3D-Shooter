using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _damage;

    public void AttackHitEvent()
    {
        if(_player == null)
        {
            return;
        }
    }
}

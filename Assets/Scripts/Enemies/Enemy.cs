using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private Player _target;
    [SerializeField]
    private float _attacDistance;
    [SerializeField]
    private float _distanceToTarget;
    [SerializeField]
    private float _damage;
    public bool _isProvoked = false;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.transform.position, transform.position);
        if(_isProvoked == true)
        {
            EngageTarget();
        }
        else if(_distanceToTarget <= _attacDistance)
        {
            _isProvoked = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _attacDistance);
    }

    private void EngageTarget()
    {
        if(_distanceToTarget >= _agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (_distanceToTarget <= _agent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public void AttackTarget()
    {
        _target.Damage(_damage);
        Debug.Log("Атака");
    }
}

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
    private float _attackDistance;
    [SerializeField]
    private float _distanceToTarget;
    [SerializeField]
    private float _damage;
    public bool _isProvoked = false;
    public bool _canAttack;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _canAttack = true;
    }

    private void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.transform.position, transform.position);
        if(_isProvoked == true)
        {
            EngageTarget();
        }
        else if(_distanceToTarget <= _attackDistance)
        {
            _isProvoked = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }

    private void EngageTarget()
    {
        if(_distanceToTarget >= _agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (_distanceToTarget <= _agent.stoppingDistance && _canAttack == true)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        _agent.SetDestination(_target.transform.position);
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("MoveTrigger");
    }

    public void AttackTarget()
    {
        _target.Damage(_damage);
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Атака");
    }
}

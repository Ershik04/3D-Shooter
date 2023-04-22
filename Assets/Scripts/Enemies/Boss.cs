using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss : MonoBehaviour
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
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _maxTimer;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _canAttack = true;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _distanceToTarget = Vector3.Distance(_target.transform.position, transform.position);
        /*if (_isProvoked == true)
        {
            EngageTarget();
        }
        else if (_distanceToTarget <= _attackDistance)
        {
            _isProvoked = true;
        }*/
        if (_timer <= 0)
        {
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
        }
        _agent.transform.LookAt(_target.transform.position);
        AttackTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }

    /*private void EngageTarget()
    {
        if (_distanceToTarget >= _agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (_distanceToTarget <= _agent.stoppingDistance && _canAttack == true)
        {
            AttackTarget();
        }
    }*/

    /*private void ChaseTarget()
    {
        _agent.SetDestination(_target.transform.position);
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("MoveTrigger");
    }*/

    public void AttackTarget()
    {
        if (_canAttack)
        {
            var ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out var hit))
            {
                print(hit.transform.name);
                var objectHit = hit.transform;
                if (objectHit != null)
                {
                    if (objectHit.tag == "Wall")
                    {
                        Destroy(hit.transform.gameObject);
                    }
                    else if (objectHit.tag == "Player")
                    {
                        objectHit.GetComponent<Player>().Damage(_damage);
                    }
                }
            }
            GetComponent<Animator>().SetBool("Attack", true);
            _timer = _maxTimer;
        }
    }
}

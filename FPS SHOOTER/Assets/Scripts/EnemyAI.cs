
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    public LayerMask ground, player;



    public Vector3 targetPoint;
    private bool targetPointSet;
    public float walkPoint;


    public float attackStart;
    private bool attackStarting;
    public GameObject apple;
    

    //visibility = görüþ mesafesi , distance= mesafe
    public float visibility, attackDistance;
    public bool playerAttackDistance, playerVisibility;




    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        playerVisibility = Physics.CheckSphere(transform.position, visibility, player);
        playerAttackDistance = Physics.CheckSphere(transform.position, attackDistance, player);


        if (!playerVisibility && !playerAttackDistance)
        {
            Travel();
        }


        if (playerVisibility && !playerAttackDistance)
        {
            Catch();
        }

        if (playerVisibility && playerAttackDistance)
        {
            Attack();
        }

    }
    
    
    void Travel()
    {
        if (!targetPointSet)
        {

        }

        if (targetPointSet)
        {
            _agent.SetDestination(targetPoint);
        }


        Vector3 targetPointCalculate = transform.position - targetPoint;
        if(targetPointCalculate.magnitude < 1f)
        {
            targetPointSet = false;
        }
    }

    void TargetPointSearch()
    {
        float randomX = UnityEngine.Random.Range(-walkPoint, walkPoint);
        float randomZ = UnityEngine.Random.Range(-walkPoint, walkPoint);

        targetPoint = new Vector3(transform.position.x + randomX , transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(targetPoint, transform.up, 2f , ground))
        {
            targetPointSet = true;
        }
    }

    void Catch()
    {
        _agent.SetDestination(_player.position);
    }

    void Attack()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if (!attackStarting)
        {
            Rigidbody rb = Instantiate(apple, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f , ForceMode.Impulse);
            rb.AddForce(transform.up * 3f, ForceMode.Impulse);

            attackStarting = true;
            Invoke(nameof(AttackBetween), attackStart);
        }
        
    }

    void AttackBetween()
    {
        attackStarting = false;
    }



    public int health = 3; // Düþmanýn baþlangýç saðlýðý

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject); // Saðlýk sýfýra ulaþtýðýnda düþmaný yok et
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 5f;



    public Transform target;
    public NavMeshAgent agent;
    
    public float health;
    public GameObject projectile;
    public float timeBetween;
    bool alreadyAttack;



    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager.instance.player.transform;

        //agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        //Chase and face player
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);


            if (distance <= attackRadius)
            {
       
                //face the target
                FaceToTarget();
                //attack
                AttackTarget();
            }
        }
        
    }

    void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void AttackTarget()
    {
        
        if (!alreadyAttack)
        {
            Rigidbody rb = Instantiate(projectile, (new Vector3(transform.position.x, 1.5f, transform.position.z)), Quaternion.identity).GetComponent<Rigidbody>();
            //Debug.Log("Before adding force: " + transform.position);

            Vector3 shootDirection = (target.position - transform.position).normalized;
            Renderer rend = rb.GetComponent<Renderer>();
            rend.material.color = Color.green;
            rb.AddForce(shootDirection * 32f, ForceMode.Impulse);

            Rigidbody rb1 = Instantiate(projectile, (new Vector3(transform.position.x, 1.5f, transform.position.z)), Quaternion.identity).GetComponent<Rigidbody>();

            Vector3 shootDirection1 = Quaternion.Euler(0, 30, 0) * (target.position - transform.position).normalized;
            Renderer rend1 = rb1.GetComponent<Renderer>();
            rend1.material.color = Color.red;
            rb1.AddForce(shootDirection1 * 32f, ForceMode.Impulse);


            Rigidbody rb2 = Instantiate(projectile, (new Vector3(transform.position.x, 1.5f, transform.position.z)), Quaternion.identity).GetComponent<Rigidbody>();

            Vector3 shootDirection2 = Quaternion.Euler(0, -30, 0) * (target.position - transform.position).normalized;
            Renderer rend2 = rb2.GetComponent<Renderer>();
            rend2.material.color = Color.green;
            rb2.AddForce(shootDirection2 * 32f, ForceMode.Impulse);



            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetween);
        }
    }
    void ResetAttack()
    {
        alreadyAttack = false;
    }

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;

    //    if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    //}
    //private void DestroyEnemy()
    //{
    //    Destroy(gameObject);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

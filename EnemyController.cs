using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    //public GameObject alertLight;
    

    Transform target;
    NavMeshAgent agent;
    //GameObject patrol;
  //  AudioSource clip;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        //this.GetComponent<AIPatrol>().enabled = false;
       // clip = GetComponent<AudioSource>();
    }
    
    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        

        if (distance <= lookRadius)
        {
            //this.GetComponent<AIPatrol>().enabled = false;
            //alertLight.SetActive(true);

          //  clip.Play();

            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}

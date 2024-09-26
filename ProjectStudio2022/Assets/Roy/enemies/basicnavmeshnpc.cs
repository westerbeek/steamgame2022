using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicnavmeshnpc : MonoBehaviour
{
    public GameObject thisenemy;
    [SerializeField]
    public Transform destination;
    public float targetdist;
    public bool activated;
    NavMeshAgent navmeshagent;
    public int enemytype;//0 = long // 1 = med // 2 = short // 3 = touch // 4 = suicide// 5 = boss
    public float length;

    // Use this for initialization
    void Update()
    {
        thisenemy = this.gameObject;


        if (destination != null)
        {
            targetdist = Vector3.Distance(destination.transform.position, this.transform.position);

            if (targetdist <= 5f)//sets the distance the npc needs to be in the block to destroy it
            {

               //Destroy(this.gameObject);

                
            }
        }
        

        navmeshagent = this.GetComponent<NavMeshAgent>();
        //gets the navmesh agent from the npc
        destination = GameObject.FindGameObjectWithTag("Player").transform;
        if (navmeshagent == null)
        {
            Debug.LogError("the nav mesh agent cant be found on: " + gameObject.name);
            //checks if there is a nav mesh if not debug
        }
        else
        {
            SetDestination();
            //function
        }
      


        
    }

    // Update is called once per frame
    public void SetDestination()
    {
        if (activated == true)
        {
            if (destination != null)
            {
                Vector3 TargetVector = destination.transform.position;
                navmeshagent.SetDestination(TargetVector);
            }
        }
    }
}

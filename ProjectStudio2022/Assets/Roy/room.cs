using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
 

    // Update is called once per frame
    public void checkoverlap()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            Debug.Log("do2");
        }
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "roomspawns")
        {
            //Destroy(other.gameObject);
            Debug.Log("do2");

        }
    }
}

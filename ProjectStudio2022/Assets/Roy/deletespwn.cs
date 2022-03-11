using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletespwn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            Destroy(this.gameObject);
            Debug.Log("do");
        }
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "room")
        {
            Destroy(this.gameObject);
            Debug.Log("do");

        }
    }
}

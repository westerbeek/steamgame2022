using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward* Time.deltaTime * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemystats>().health -= damage;
            Destroy(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

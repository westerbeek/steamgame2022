using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystats : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(this.gameObject);

    }
}

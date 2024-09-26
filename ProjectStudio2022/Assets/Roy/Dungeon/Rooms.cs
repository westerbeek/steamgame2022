using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        spawns = new GameObject[4];
        spawns[0] = GameObject.Find("spawnleft");
        spawns[1] = GameObject.Find("spawnright");
        spawns[2] = GameObject.Find("spawnup");
        spawns[3] = GameObject.Find("spawndown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

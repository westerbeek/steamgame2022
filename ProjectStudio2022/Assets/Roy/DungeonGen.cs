using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DungeonGen : MonoBehaviour
{
    public GameObject startroom;
    public GameObject[] rooms;
    public GameObject bossroom;
    public int numofrooms;

    public List<Transform> spawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDungeon();
    }
    void GenerateDungeon()
    {

        Instantiate(startroom, new Vector3(0,0,0), Quaternion.identity);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("roomspawns"))
        {
            spawnpoints.Add(go.GetComponent<Transform>());
        }
        for (int i = 0; i < numofrooms; i++)
        {
            int tmp = spawnpoints.Count;
            int num = Random.Range(0, tmp);

            Instantiate(rooms[0], new Vector3(spawnpoints[num].position.x, spawnpoints[num].position.y, spawnpoints[num].position.z), Quaternion.identity);
            spawnpoints.Remove(spawnpoints[num]);
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("roomspawns"))
            {
                spawnpoints.Add(go.GetComponent<Transform>());
            }
        }
    }

}

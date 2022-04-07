using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DungeonGen : MonoBehaviour
{
    public GameObject startroom;
    public GameObject[] rooms;//prefabs
    public GameObject bossroom;
    public int numofrooms;

    public List<Transform> spawnpoints;
    public List<GameObject> roomsinscene;
    private bool finalroom;

    public string seedtext;
    public bool setseed;
    public int seed;

    // Start is called before the first frame update
    void Start()
    {

        if(setseed == false)
        {
            seed = Random.Range(0,99999999);
        }
        else
        {
            seed = seedtext.GetHashCode();
        }

        Random.InitState(seed);
        startroomDungeon();
    }
    void startroomDungeon()
    {
        roomsinscene.Add(Instantiate(startroom, new Vector3(0, 0, 0), Quaternion.identity));//spawns the room the player spawns in
        getroomloc();
    }

    void getroomloc()
    {
        spawnpoints = new List<Transform>();//resets de list
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("roomspawns"))
        {
            spawnpoints.Add(go.GetComponent<Transform>());//adds all roomspawn locations to the list
        }
        generateroom();
    }

    void generateroom()
    {

        if (roomsinscene.Count < numofrooms)
        {
            bool safe = true;
            int num = Random.Range(0, spawnpoints.Count);//gets random spawn point

            GameObject tmpobj = Instantiate(rooms[Random.Range(0, rooms.Length)], new Vector3(spawnpoints[num].position.x, spawnpoints[num].position.y, spawnpoints[num].position.z), Quaternion.identity);
            for (int i = 0; i < roomsinscene.Count; i++)
            {
                if (tmpobj.transform.position == roomsinscene[i].transform.position)// looks throuhg all rooms if there is already a room on location
                {
                    safe = false;
                    Destroy(tmpobj);
                }
            }
            if (safe == true)
            {
                roomsinscene.Add(tmpobj);
                getroomloc();
            }
            else//if safe == false it tries again
            {
                generateroom();
            }
        }

        if (roomsinscene.Count >= numofrooms && finalroom == false){
            bool safe = true;
            int num = Random.Range(0, spawnpoints.Count);//gets random spawn point

            GameObject tmpobj = Instantiate(bossroom, new Vector3(spawnpoints[num].position.x, spawnpoints[num].position.y, spawnpoints[num].position.z), Quaternion.identity);
            for (int i = 0; i < roomsinscene.Count; i++)
            {
                if (tmpobj.transform.position == roomsinscene[i].transform.position)// looks throuhg all rooms if there is already a room on location
                {
                    safe = false;
                    Destroy(tmpobj);
                }
            }
            if (safe == true)
            {
                roomsinscene.Add(tmpobj);
                finalroom = true;
                getroomloc();
            }
            else//if safe == false it tries again
            {
                generateroom();
            }
        }
    }
        
    


}
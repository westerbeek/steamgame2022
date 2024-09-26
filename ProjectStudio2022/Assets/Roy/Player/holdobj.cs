using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdobj : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;
    public Camera maincam;
    public Vector3 mousepos;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 9999;
        
        player = GameObject.Find("Player");
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    public Transform target;

    // Angular speed in radians per sec.

    void Update()
    {
      
        if (this.gameObject.transform.localRotation.y < -0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

  
        }
        if (this.gameObject.transform.localRotation.y >= 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);


        } 
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            target.position = new Vector3(hit.point.x, player.transform.position.y - 0.01f, hit.point.z);
        }

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y, eulerRotation.z);
   
        //rotate gun when on other side
       
    }
}

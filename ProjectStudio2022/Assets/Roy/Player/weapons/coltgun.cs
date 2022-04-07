using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coltgun : weapon
{
    // Start is called before the first frame update
    void Start()
    {
        attackspeed = maxattackspeed;
        currentammo = maxammo;
    }

    // Update is called once per frame
    void Update()
    {
        attackspeed -= Time.deltaTime;
        if (currentammo > 0 && reloading == false)
        {
            if (attackspeed <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    //Attack();
                }
            }
        }
        else if (amountclips > 0)
        {
            reloading = true;
        }
        if(currentammo < maxammo && Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
        }
        if(reloading == true)
        {
            Reload();
        }
        
    }

    void Reload()
    {
        reloadtime -= Time.deltaTime * reloadspeed;
        if(reloadtime <= 0)
        {
            currentammo = maxammo;
            amountclips -= 1;
            reloadtime = maxreloadtime;
            reloading = false;
        }
    }
    void Attack()
    {
        GameObject bullet1 = Instantiate(Bulletobj, attackpos.position, this.transform.parent.transform.rotation);
        bullet1.GetComponent<bullet>().speed = bulletspeed;
        bullet1.GetComponent<bullet>().damage = damage;
        currentammo -= 1;
        attackspeed = maxattackspeed;

    }
}

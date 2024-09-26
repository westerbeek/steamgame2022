using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    public float damage;
    [SerializeField]
    public float range;
    [SerializeField]
    public int weapontype;
    [SerializeField] 
    public float attackspeed;
    public float maxattackspeed;
    public float bulletspeed;

    public int maxammo;
    public int currentammo;
    public int amountclips;
    public int maxamountclips;

    public float reloadtime;
    public float maxreloadtime;
    public float reloadspeed;
    public bool reloading;

    public Transform attackpos;
    public GameObject Bulletobj;
    // Start is called before the first frame update
 
}

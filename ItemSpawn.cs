using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour
{

    //GameObject, we will get its x-position to calculate max x-position from spawned item
    public GameObject RightSide;
    //array with gameobjects, wich will be spawned
    public GameObject[] items;
    //float variables: start delay befor first spawn, repeat delay between spawns
    public float startDelay, repeatRate;

    //will be executed once at start
    void Start()
    {
        //start spawn function
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    //spawn function, will be executed all time with repeat rate
    void Spawn()
    {
        //calculate random position: x is random between Spawn and RightSide
        Vector3 pos = new Vector3(Random.Range(gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, 0);
        //place random gameobject from array into calculated position
        Instantiate(items[Random.Range(0, items.Length)], pos, gameObject.transform.rotation);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    [SerializeField] private float waitTime = 4f;

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    GameObject go;

    void Start()
    {
        if(!gameObject.tag.Equals("closedRoom"))
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.getBottomRoomsLength());
                go = Instantiate(templates.getBottomRooms(rand), transform.position, Quaternion.identity);
                go.transform.parent = GameObject.Find("Grid").transform;
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.getTopRoomsLength());
                go = Instantiate(templates.getTopRooms(rand), transform.position, Quaternion.identity);
                go.transform.parent = GameObject.Find("Grid").transform;
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.getLeftRoomsLength());
                go = Instantiate(templates.getLeftRooms(rand), transform.position, Quaternion.identity);
                go.transform.parent = GameObject.Find("Grid").transform;
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.getRightRoomsLength());
                go = Instantiate(templates.getRightRooms(rand), transform.position, Quaternion.identity);
                go.transform.parent = GameObject.Find("Grid").transform;
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("SpawnPoint"))
        {
            try
            {
                if (otherCollider.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    go = Instantiate(templates.getClosedRoom(), transform.position, Quaternion.identity);
                    go.transform.parent = GameObject.Find("Grid").transform;
                    Destroy(gameObject);
                }
                spawned = true;
            }
            catch (System.Exception e)
            {
            }
        }
    }
}

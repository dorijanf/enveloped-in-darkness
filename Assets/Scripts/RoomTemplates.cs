using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
    [SerializeField] private GameObject[] topRooms;
    [SerializeField] private GameObject[] rightRooms;
    [SerializeField] private GameObject[] bottomRooms;
    [SerializeField] private GameObject[] leftRooms;
    [SerializeField] private GameObject closedRoom;
    [SerializeField] private Sprite[] shardSprites;
    [SerializeField] private Sprite[] shardSpritesUI;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject shardsCollected;
    [SerializeField] private float waitTime = 5f;

    private bool spawnedShard;
    private int rand;
    public List<GameObject> rooms;
    public bool isCollected;
    int spriteCounter;
    int spriteCounterUI;
    int randomPercentage;
    int closedRoomNumber;

    private void Start()
    {
        spawnedShard = false;
        spriteCounter = 0;
        spriteCounterUI = 0;
    }

    void Update()
    {
        if (isCollected)
        {
            spawnedShard = false;
        }

        if (spriteCounter == 6)
        {
            SceneManager.LoadScene("Win");
        }

        if (waitTime <= 0 && spawnedShard == false)
        {
            isCollected = false;
            if (waitTime == 3)
            {
                rooms.Remove(rooms[5]);
            }

            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    randomPercentage = Random.Range(0, 100);
                    if (randomPercentage > 30)
                    {
                        spawnShard(spriteCounter, closedRoomNumber);
                        shardsCollected.GetComponent<Image>().sprite = shardSpritesUI[spriteCounterUI];
                        spriteCounterUI += 1;
                        spriteCounter += 1;
                    }
                    else
                    {
                        spawnFakeShard(spriteCounter, closedRoomNumber);
                        shardsCollected.GetComponent<Image>().sprite = shardSpritesUI[spriteCounterUI];
                    }
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void spawnShard(int counter, int closedRoomNumber)
    {
        rand = Random.Range(0, rooms.Count - 1);
        GameObject gO = objectPooler.SpawnFromPool("shard", rooms[rand].transform.position, Quaternion.identity);
        if (gO != null)
        {
            gO.GetComponentInChildren<SpriteRenderer>().sprite = shardSprites[counter];
        }
        spawnedShard = true;
    }

    public void spawnFakeShard(int counter, int closedRoomNumber)
    {

        rand = Random.Range(0, rooms.Count - 1);
        GameObject gO = objectPooler.SpawnFromPool("fakeShard", rooms[rand].transform.position, Quaternion.identity);
        if (gO != null)
        {
            gO.GetComponentInChildren<SpriteRenderer>().sprite = shardSprites[counter];
        }
        spawnedShard = true;
    }

    public GameObject getTopRooms(int num)
    {
        return topRooms[num];
    }

    public GameObject getRightRooms(int num)
    {
        return rightRooms[num];
    }

    public GameObject getBottomRooms(int num)
    {
        return bottomRooms[num];
    }

    public GameObject getLeftRooms(int num)
    {
        return leftRooms[num];
    }

    public GameObject getClosedRoom()
    {
        return closedRoom;
    }

    public int getTopRoomsLength()
    {
        return topRooms.Length;
    }

    public int getRightRoomsLength()
    {
        return rightRooms.Length;
    }

    public int getBottomRoomsLength()
    {
        return bottomRooms.Length;
    }

    public int getLeftRoomsLength()
    {
        return leftRooms.Length;
    }
}
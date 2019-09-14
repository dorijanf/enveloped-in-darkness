using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float movementSpeed = 4f;
    [SerializeField] private float waitTime = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }
    void Update()
    {
        if (waitTime <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!otherCollider.GetComponent<Shard>() || !otherCollider.GetComponent<FakeShard>())
        {
            if (otherCollider.GetComponent<PlayerController>())
            {
                SceneManager.LoadScene("Win2");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!otherCollider.GetComponent<PlayerController>())
        {
            Destroy(otherCollider.gameObject);
        }
    }
}

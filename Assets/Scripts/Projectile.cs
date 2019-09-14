using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject
{
    [SerializeField] private float projectileSpeed = 1;
    [SerializeField] private float thrust = 0.2f;
    [SerializeField] GameObject destructionVFX;
    Vector3 moveDirection;
    private float timer = 3f;

    public void Start()
    {
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }
    public void OnObjectSpawn()
    {
    }

    private void Update()
    {
        transform.position = transform.position + moveDirection * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!otherCollider.GetComponent<PlayerController>() && !otherCollider.GetComponent<Shard>() && !otherCollider.GetComponent<FakeShard>())
        {
            if (!destructionVFX)
            {
                return;
            }
            if (otherCollider.tag == "wall")
            {
                GameObject destructionVFXObj = Instantiate(destructionVFX, transform.position, Quaternion.identity);
                Destroy(destructionVFXObj, 3f);
                Destroy(gameObject, 3f);
            }

            if (otherCollider.GetComponent<Enemy>())
            {
                GameObject destructionVFXObj = Instantiate(destructionVFX, transform.position, Quaternion.identity);
                Destroy(destructionVFXObj, 3f);
                otherCollider.GetComponent<Enemy>().movementSpeed = 0;
                otherCollider.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 255, 246, 255);
                StartCoroutine(freezeMovement(otherCollider));
            }
        }
    }

    private IEnumerator freezeMovement(Collider2D otherCollider)
    {
        yield return new WaitForSeconds(2f);
        if (otherCollider.tag == "ded")
        {
            otherCollider.GetComponent<Enemy>().movementSpeed = 1.5f;
        }
        if (otherCollider.tag == "dedd")
        {
            otherCollider.GetComponent<Enemy>().movementSpeed = 4f;
        }
        if (otherCollider.tag == "deddy")
        {
            otherCollider.GetComponent<Enemy>().movementSpeed = 3f;
        }
        otherCollider.GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        Destroy(gameObject);
    }
}

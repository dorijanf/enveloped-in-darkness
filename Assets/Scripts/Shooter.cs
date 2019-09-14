using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float startTimeBetweenShots;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject projectile;
    ObjectPooler objectPooler;
    private float timeBetweenShots;

    
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootProjectile();
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    public void ShootProjectile()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}

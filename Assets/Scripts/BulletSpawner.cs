using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float fireDelay;
    float lastFire;

    private void Start()
    {
        lastFire = fireDelay;
    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        if (lastFire >= fireDelay)
        {
            // reset timer
            lastFire = 0.0f;
            // fire
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
            bullet.transform.forward = this.transform.right;
        }
    }
}

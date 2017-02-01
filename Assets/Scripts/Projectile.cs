using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    bool live = true;

    Rigidbody rbdy;

    private void Awake()
    {
        rbdy = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (live)
        {
            this.transform.Translate(this.transform.forward * speed * Time.deltaTime, Space.World);
        }
    }

    public void InteractWithShield()
    {
        Debug.Log(gameObject.name + " INTERACT WITH SHIELD");
        rbdy.useGravity = true;
        rbdy.isKinematic = false;
        live = false;
    }
}

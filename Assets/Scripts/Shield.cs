using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float rotateSpeed = 180.0f;
    private void Update()
    {
        this.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // get shield interaction Component of other and signal shield collision
        ShieldInteraction si = other.GetComponent<ShieldInteraction>();
        if (si != null)
        {
            Debug.Log("HIT DETECTED");
            si.ShieldHit();
        }
    }
}

using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private BoxCollider box = null;
    public GameObject owner = null;

    private PlayerMovement script = null;
    void Start()
    {
        box = GetComponent<BoxCollider>();
        script = owner.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") == false)
            return;

        Debug.Log(other.gameObject.name);
        script.on_ground = true;
        script.TriggerFly();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") == false)
            return;

        Debug.Log(other.gameObject.name);
        script.on_ground = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") == false)
            return;

        Debug.Log("Not On Ground");
        script.on_ground = false;
    }
}

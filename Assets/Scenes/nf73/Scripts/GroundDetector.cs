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

    void Update()
    {
        if (owner == null)
            return;

        transform.position = owner.transform.position + new Vector3(0, -1.4f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        script.on_ground = true;
        script.TriggerFly();
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        script.on_ground = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Not On Ground");
        script.on_ground = false;
    }
}

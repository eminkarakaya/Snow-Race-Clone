using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    RollSnow rollSnow;
    private void Start()
    {
        rollSnow = GetComponentInParent<RollSnow>();
        Physics.IgnoreCollision(GetComponent<Collider>(), GetComponentInParent<BoxCollider>());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rollSnow.Fall(other);
        }
    }
}

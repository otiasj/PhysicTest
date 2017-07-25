using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    public int degreesPerSecond;
    public int blowingForce;
    private Vector3 force;

    void Update () {
        transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
        force = -this.transform.forward * blowingForce;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(GetComponent<Collider>().name + "<->" + other.name);
        //Debug.DrawRay(other.attachedRigidbody.position, force, Color.white);
        other.attachedRigidbody.AddForceAtPosition(force, other.attachedRigidbody.position);
    }

}

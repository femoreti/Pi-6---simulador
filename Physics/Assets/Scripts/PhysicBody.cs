using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBody : MonoBehaviour
{
    public bool isKinematic;

    [HideInInspector]
    public Vector3 velocity;
    Vector3 acceleration;
    public float mass;
    private Vector3 sumForces;

    private void FixedUpdate()
    {
        if (isKinematic)
            return;

        transform.Translate(new Vector3(acceleration.x * Time.fixedDeltaTime, acceleration.y * Time.fixedDeltaTime, acceleration.z * Time.fixedDeltaTime));
    }

    public void AddForce(Vector3 force)
    {
        this.sumForces += force * Time.deltaTime;
        this.acceleration = this.sumForces / this.mass;

        velocity = acceleration;
    }
}

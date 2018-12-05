using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBody : MonoBehaviour
{
    public bool isKinematic;

    public Vector3 velocity;
    public Vector3 acceleration;
    public float mass;
    public Vector3 gravity;
    private Vector3 sumForces;

    private void FixedUpdate()
    {
        if (isKinematic)
            return;

        transform.Translate(new Vector3(acceleration.x * Time.fixedDeltaTime, acceleration.y * Time.fixedDeltaTime, acceleration.z * Time.fixedDeltaTime));
    }

    public void AddForceMethod(Vector3 force)
    {
        this.sumForces += force * Time.deltaTime;
        this.acceleration = this.sumForces / this.mass;
    }
}

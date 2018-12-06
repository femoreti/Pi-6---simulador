using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBody : MonoBehaviour
{
    public bool isKinematic;

    [HideInInspector]
    public Vector3 velocity;
    Vector3 acceleration;
    Vector3 accelerationRelative;
    public float mass = 1;
    private Vector3 sumForces;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        if (isKinematic)
            return;

        transform.Translate(new Vector3(acceleration.x * Time.fixedDeltaTime, 
            acceleration.y * Time.fixedDeltaTime, 
            acceleration.z * Time.fixedDeltaTime));

        transform.Translate(new Vector3(accelerationRelative.x * Time.fixedDeltaTime, 
            accelerationRelative.y * Time.fixedDeltaTime, 
            accelerationRelative.z * Time.fixedDeltaTime), Space.World);
    }

    public void AddForce(Vector3 force)
    {
        this.sumForces += force * Time.deltaTime;
        this.acceleration = this.sumForces / 1;

        velocity += acceleration;
    }

    public void AddRelativeForce(Vector3 force)
    {
        //Debug.Log("add force " + force);
        this.sumForces += force * Time.deltaTime;
        this.accelerationRelative = this.sumForces / this.mass;
    }

    private void OnCollisionEnter(Collision collision)
    {
        acceleration = Vector3.zero;
        accelerationRelative = Vector3.zero;
        velocity = Vector3.zero;
        sumForces = Vector3.zero;
    }
}

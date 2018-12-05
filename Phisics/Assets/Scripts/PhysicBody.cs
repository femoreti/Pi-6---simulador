using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBody : MonoBehaviour
{
    public Vector3D Position;
    public Vector3D Velocity;
    public Vector3D Acceleration;
    public float Mass;
    public Vector3D Gravity;
    public Vector3D SumForces;

    public Vector3D getSumForces()
    {
        return this.SumForces;
    }

    public PhysicBody(Vector3D position, Vector3D velocity, Vector3D acceleration, float mass, Vector3D gravity)
    {
        this.Position = position;
        this.Velocity = velocity;
        this.Acceleration = acceleration;
        this.Mass = mass;
        this.Gravity = gravity;
    }
    public void AddForceMethod(Vector3D force)
    {
        this.SumForces += force;
        this.Acceleration = this.SumForces / this.Mass;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDemo : MonoBehaviour
{

    public PhysicBody teste;
    // Use this for initialization
    void Start()
    {

        Vector3D velocity = gameObject.AddComponent<Vector3D>();
        Vector3D position = gameObject.AddComponent<Vector3D>();
        Vector3D acceleration = gameObject.AddComponent<Vector3D>();
        Vector3D gravity = gameObject.AddComponent<Vector3D>();
        Vector3D sumForces = gameObject.AddComponent<Vector3D>();

        teste = GetComponent<PhysicBody>();
        teste.Velocity = velocity;
        teste.Position = position;
        teste.Acceleration = acceleration;
        teste.Gravity = gravity;
        teste.Mass = 20;
        teste.SumForces = sumForces;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3D force = gameObject.AddComponent<Vector3D>();
        force.y = force.y + 10;
        teste.AddForceMethod(force);

        teste.transform.Translate(new Vector3(teste.Acceleration.x, teste.Acceleration.y, teste.Acceleration.z));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector3D : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public static Vector3D operator+(Vector3D vector1, Vector3D vector2)
    {
        return new Vector3D(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
    }
    public static Vector3D operator-(Vector3D vector1, Vector3D vector2)
    {
        return new Vector3D(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
    }

    public static Vector3D operator/(Vector3D vector, float value)
    {
        return new Vector3D(vector.x / value, vector.y / value, vector.z / value);
    }
    public static Vector3D operator*(Vector3D vector, float value)
    {
        return new Vector3D(vector.x * value, vector.y * value, vector.z * value);
    }

    public Vector3D(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3D(Vector3D existingVector3D)
    {
        this.x = existingVector3D.x;
        this.y = existingVector3D.y;
        this.z = existingVector3D.z;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Transform target;
    public float scrollSpeed = 15f;
    public float camZoomSpeed = 75f, camMoveSpeed = 25f;

    Vector3 newPos = Vector3.zero, startPos;

    bool started = false;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
    }
	
    public void OnInit()
    {
        OnSetTarget(GameObject.FindWithTag("Sun").transform);

        transform.position = startPos;
        float distance = 250f;
        newPos = -(transform.forward * distance) + target.position;

        started = true;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!started)
            return;

        if (target != null)
        {
            transform.LookAt(target, Vector3.up);
        }
        else
            return;

        if (Input.mouseScrollDelta.y != 0f)
        {
            //newPos = (transform.position + new Vector3(0, 0, scrollSpeed * Input.mouseScrollDelta.y));

            float distance = Vector3.Distance(transform.position, target.position);

            distance -= scrollSpeed * Input.mouseScrollDelta.y;
            newPos = -(transform.forward * distance) + target.position;
        }
        
        if(Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * -camMoveSpeed;
            transform.RotateAround(target.position, Vector3.up, rotationX);

            float rotationY = Input.GetAxis("Mouse Y") * camMoveSpeed;
            transform.RotateAround(target.position, Vector3.right, rotationY);


            newPos = transform.localPosition;

            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, camZoomSpeed * Time.deltaTime);
	}

    public void OnSetTarget(Transform p_target)
    {
        target = p_target;

        float distance = 350f * target.localScale.x / 30f;
        newPos = -(transform.forward * distance) + target.position;
        transform.position = newPos;
    }
}

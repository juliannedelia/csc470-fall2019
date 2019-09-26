using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject plane;

    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + plane.transform.forward * -8.0f + Vector3.up * 3.0f;
        transform.LookAt(plane.transform.position);
    }
}

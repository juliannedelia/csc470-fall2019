using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject lulu;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lulu.transform.position + lulu.transform.forward * -4.128f + Vector3.up * 3.0f;
        //transform.LookAt(lulu.transform.position);
        transform.LookAt(lulu.transform.position + lulu.transform.forward * 5.0f);
    }
}


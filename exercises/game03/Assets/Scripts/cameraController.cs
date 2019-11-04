using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject unit;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = unit.transform.position + unit.transform.forward * -8.0f + Vector3.up * 3.0f;
        transform.LookAt(unit.transform.position);
    }
}

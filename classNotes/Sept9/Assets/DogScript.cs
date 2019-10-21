using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    float speed = 5f;

    public GameObject treeObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vecToTree = treeObj.transform.position - gameObject.transform.position;
        //vecToTree = vecToTree.normalized;

        //transform.position = transform.position + vecToTree * speed * Time.deltaTime;

        gameObject.transform.LookAt(treeObj.transform, Vector3.up);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}

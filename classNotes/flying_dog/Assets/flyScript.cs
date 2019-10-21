using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flyScript : MonoBehaviour
{
    float speed = 10f;

    public GameObject moonObj;
    public Text gameLabelText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vecToMoon = treeObj.transform.position - gameObject.transform.position;
        //vecToMoon = vecToMoon.normalized;

        //transform.position = transform.position + vecToTree * speed * Time.deltaTime;

        if(moonObj != null)
        {
            gameObject.transform.LookAt(moonObj.transform, Vector3.up);
        }
        else
        {
            gameObject.transform.LookAt(Camera.main.transform, Vector3.up);
        }

        //gameObject.transform.LookAt(moonObj.transform, Vector3.up);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEvent(Collider other)
    {
        Destroy(other.gameObject);
        gameLabelText.text = "Spike is comin for ya!";
    }
}

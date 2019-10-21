using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject hotDogPrefab;

    float rotSpeed = 65;
    float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotSpeed * Time.deltaTime * hAxis, 0);
        transform.position += transform.forward * moveSpeed * Time.deltaTime * vAxis;

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 pos = transform.position + Vector3.up * 1.75f + transform.forward * 0.5f;
            GameObject hdog = Instantiate(hotDogPrefab, pos, transform.rotation);
            Destroy(hdog, 3);
        }
    }
}

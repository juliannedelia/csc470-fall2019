using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busterScript1 : MonoBehaviour
{

    public float speed = 0.5f;
    Vector3 pointA;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector3(-20.3f, 0, -2.27f);
        pointB = new Vector3(-20.3f, 0, -10.88f);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}

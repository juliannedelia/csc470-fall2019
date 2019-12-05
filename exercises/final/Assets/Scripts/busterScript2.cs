using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busterScript2 : MonoBehaviour
{
    public float speed = 0.5f;
    Vector3 pointA;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector3(21.09f, 0, 19.9f);
        pointB = new Vector3(11.96f, 0, 19.9f);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}

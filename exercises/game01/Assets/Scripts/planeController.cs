using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planeController : MonoBehaviour
{
    float moveSpeed = 50;
    float rotSpeed = 90;
    public Text countText;
    public Text winText;
    public Text timerText;
    private Rigidbody rigidbody;
    private int count; 
    public float timeRemaining = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        timerText.text = "";
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining > 0.0f)
        {
            timerText.text = "TIME: " + (int)timeRemaining;
        }
        else
        {
            timerEnded();
        }
    }
    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Rotate(0, rotSpeed * Time.deltaTime * hAxis, 0);
        transform.position += transform.forward * moveSpeed * Time.deltaTime * vAxis;
        
    } 

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 11 && timeRemaining > 0.0f)
        {
            winText.text = "You Win!";
            timeRemaining = Time.deltaTime;
            timerText.text = "TIME: " + (int)timeRemaining;
        }
    }

    void timerEnded()
    {
        if(timeRemaining <= 0.0f && count < 11)
        {
            winText.text = "Times up. You lose!";
            timerText.text = "TIME'S UP!";
        }
        else
        {
            SetCountText();
        }
    } 

}

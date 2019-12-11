using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class luluController : MonoBehaviour
{
    float moveSpeed = 5;
    float rotSpeed = 60;

    public Text countText;
    private int count;

    CharacterController cc;

    bool isActive;

    public GameObject dinerPrefab;
    public GameObject archPrefab;

    //private int healthPP;

    public float x = 1.1f;
    public float y = 1.1f;
    public float z = 1.1f;

    bool power = false;

    public Image powerImage;
    public Color powerflashColor = new Color(1f, 0f, 0f, 0.1f);
    public Image normalImage;
    public Color normalColor = new Color(0f, 0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        count = PlayerPrefs.GetInt("score");
       
        // PlayerPrefs.SetInt("Score", count);
        // PlayerPrefs.Save();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Rotate(0, rotSpeed * Time.deltaTime * hAxis, 0);

        //Vector3 amountToMove = transform.forward * moveSpeed * Time.deltaTime * vAxis;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            cc.Move(transform.forward * moveSpeed * Time.deltaTime * vAxis);
        }

       
            
        //transform.position += transform.forward * moveSpeed * Time.deltaTime * vAxis;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("food"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            PlayerPrefs.SetInt("score", count);
            SetCountText();
        }

        if(other.gameObject.CompareTag("donut"))
        {
            other.gameObject.SetActive(false);
            count = count + 20;
            PlayerPrefs.SetInt("score", count);
            SetCountText();
            dinerPrefab.gameObject.SetActive(true);
            archPrefab.gameObject.SetActive(true);
        }

        if(other.gameObject.CompareTag("garbage"))
        {
            other.gameObject.SetActive(false);
            count = count - 10;
            PlayerPrefs.SetInt("score", count);
            SetCountText();
        }

        if(other.gameObject.CompareTag("buster"))
        {
            if(power == false)
            {
                //SceneManager.LoadScene("lose");
                count = count - 10;
                PlayerPrefs.SetInt("score", count);
                SetCountText();
                luluHealth health = gameObject.GetComponent<luluHealth>();
                health.TakeDamage();
                //PlayerPrefs.SetInt("health", healthPP);
                //Debug.Log("hit by buster");
            }
            
            if(power == true)
            {
                other.gameObject.SetActive(false);
                count = count + 50;
                SetCountText();
                PlayerPrefs.SetInt("score", count);
            }
        }

        if(other.gameObject.CompareTag("diner"))
        {
            count = count + 100;
            SetCountText();
            PlayerPrefs.SetInt("score", count);
            SceneManager.LoadScene("win");
        } 

        if(other.gameObject.CompareTag("archway1"))
        {
            count = count + 100;
            SetCountText();
            PlayerPrefs.SetInt("score", count);
            SceneManager.LoadScene("level2");
        } 

        if(other.gameObject.CompareTag("water"))
        {
            power = true;
            
            other.gameObject.SetActive(false);
            count = count + 20;
            SetCountText();
            PlayerPrefs.SetInt("score", count);
            PowerUp();
        }     
    }

    void SetCountText()
    {
        //PlayerPrefs.SetInt("Score: ", count);
        countText.text = "Score: " + count.ToString();
    }

    void PowerUp()
    {
        transform.localScale = new Vector3(x, y, z);
        StartCoroutine(PowerUpWearOff(5f));
        if(power)
        {
            powerImage.color = powerflashColor;
        }
        else
        {
            powerImage.color = normalColor;
        }
    }

    IEnumerator PowerUpWearOff(float waitTime)
    {
        //PlayerShooting.timeBetweenBullets -= RFBoostValue; // add boost
        yield return new WaitForSeconds(waitTime);
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        power = false;
        powerImage.color = normalColor;
        //PlayerShooting.timeBetweenBullets += RFBoostValue; // remove boost
    }

}

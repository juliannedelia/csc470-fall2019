using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    float speed = 5f;
    GameObject unitObj;
    GameObject villianObj;

    GameObject merry;

    // Start is called before the first frame update
    void Start()
    {
        merry = GameObject.Find("Merry");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        // transform.LookAt(merry.transform, Vector3.up);
    }


    void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "wall")
		{
			Destroy(gameObject);
		}

        if(c.gameObject.tag == "merry" && gameObject.tag == "insult")
        {
            playerHealth us = c.gameObject.GetComponent<playerHealth>();
            us.TakeDamage(10);
            Debug.Log("hit by villian");
            /* if(us.health == 0)
            {
                SceneManager.LoadScene("youLose");
            } */
        }

        if(c.gameObject.tag == "villian" && gameObject.tag == "merryWords")
        {
            playerHealth vs = c.gameObject.GetComponent<playerHealth>();
            vs.TakeDamage(10);
            Debug.Log("hit by hero");
            /* if(vs.health == 0)
            {
                SceneManager.LoadScene("youWin");
            } */
        }
	}
}

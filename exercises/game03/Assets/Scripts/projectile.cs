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
        //StartCoroutine(Delay());
        transform.position += transform.forward * speed * Time.deltaTime;

        // transform.LookAt(merry.transform, Vector3.up);
    }

   /*  IEnumerator Delay()
    {
        //print(Time.time);
        yield return new WaitForSeconds(5);
        //print(Time.time);
    } */

    void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "wall")
		{
			Destroy(gameObject);
		}

        if(c.gameObject.tag == "merry")
        {
            playerHealth us = c.gameObject.GetComponent<playerHealth>();
            us.TakeDamage(10);
            Debug.Log("hit");
            /* if(us.health == 0)
            {
                SceneManager.LoadScene("youLose");
            } */
        }

        if(c.gameObject.tag == "villian" && gameObject.tag == "merryWords")
        {
            playerHealth vs = c.gameObject.GetComponent<playerHealth>();
            vs.TakeDamage(10);
            /* if(vs.health == 0)
            {
                SceneManager.LoadScene("youWin");
            } */
        }
	}
}

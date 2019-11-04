using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    float speed = 5f;
    GameObject unitObj;
    GameObject villianObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Delay());
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator Delay()
    {
        //print(Time.time);
        yield return new WaitForSeconds(5);
        //print(Time.time);
    }

    void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "wall")
		{
			Destroy(gameObject);
		}

        if(c.gameObject.tag == "merry")
        {
            UnitScript us = unitObj.AddComponent<UnitScript>();
            us.health -= 1;
            if(us.health == 0)
            {
                SceneManager.LoadScene("youLose");
            }
        }

        if(c.gameObject.tag == "villian")
        {
            VillianScript vs = villianObj.AddComponent<VillianScript>();
            vs.health -= 1;
            if(vs.health == 0)
            {
                SceneManager.LoadScene("youWin");
            }
        }
	}
}

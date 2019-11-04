using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;                                   
    public Slider healthSlider; 
    
    //bool isDead;
    bool damanged;

    public GameObject unitPrefab;                               

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damanged = false;
    }

    public void TakeDamage(int amount)
    {
        damanged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth == 0)
        {
            Death();
        }
    }

    void Death()
    {
        if(unitPrefab.gameObject.tag == "merry")
        {
            SceneManager.LoadScene("youLose");
        }

        if(unitPrefab.gameObject.tag == "villian")
        {
            Destroy(unitPrefab);
        }
        //isDead = true;
        //Destroy(unitPrefab);

    }
}

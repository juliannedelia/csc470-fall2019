using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class luluHealth : MonoBehaviour
{
   // public int startingHealth = 3;
    private int currentHealth;
    //private int healthPP;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    //AudioSource playerAudio;
    bool isDead;
    bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health");
        //healthPP = PlayerPrefs.GetInt("health");
        //currentHealth = PlayerPrefs.GetInt("health");
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage() //int amount
    {
        int amount = 1;

        damaged = true;

        currentHealth -= amount;
        PlayerPrefs.SetInt("health", currentHealth);

        healthSlider.value = currentHealth;

        //playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        SceneManager.LoadScene("lose");
    }
}

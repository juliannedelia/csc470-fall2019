using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("health", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressStart()
    {
        SceneManager.LoadScene("level1");
    }
}



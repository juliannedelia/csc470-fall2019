using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{

    public Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        finalScoreText.text = PlayerPrefs.GetInt("score").ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

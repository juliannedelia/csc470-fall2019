using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Text chargeEnergyText;
    float chargeEnergy = 0;
    float chargeRate = 500;


    // Start is called before the first frame update
    void Start()
    {
        chargeEnergyText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            chargeEnergy += chargeRate * Time.deltaTime;
            chargeEnergyText.text = chargeEnergy.ToString();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.useGravity = true;
            rigidbody.AddForce(transform.forward * chargeEnergy);
            chargeEnergy = 0;
        }
    }
}

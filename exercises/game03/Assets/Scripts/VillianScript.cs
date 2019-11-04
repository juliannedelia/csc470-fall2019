using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillianScript : MonoBehaviour
{
    public string name;
	public Sprite portrait;

    public bool selected = false;
	bool hover = false;

	//public float health;

	Color defautColor;
	public Color hoverColor;
	public Color selectedColor; 

    public GameObject InsultPrefab;

    public float health;
    GameManager gm;
    CharacterController cc;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        GameObject gmObj = GameObject.Find("GameManagerObject");
		gm = gmObj.GetComponent<GameManager>();

        cc = gameObject.GetComponent<CharacterController>();

        defautColor = rend.material.color;

        setColorOnMouseState();

        StartCoroutine(DelayShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void setColorOnMouseState()
	{
		if (selected) 
		{
			rend.material.color = selectedColor;
		} 
		else if (hover) 
		{
			rend.material.color = hoverColor;
		} 
		else 
		{
			rend.material.color = defautColor;
		}
	}

    IEnumerator DelayShoot()
    {
        while(true) {
            Vector3 pos = transform.position + Vector3.up * 0.1f + transform.forward * 0.1f;
            GameObject insult = Instantiate(InsultPrefab, pos, transform.rotation);
            Destroy(insult, 2);
            //print(Time.time);
            yield return new WaitForSeconds(1);
            //print(Time.time);
        }
    }

    private void OnMouseOver()
	{
		hover = true;
		setColorOnMouseState();

		gm.villianHealthMeterObject.SetActive(true);
		gm.villianMeter.fillAmount = health / 100;
		gm.villianHealthMeterObject.transform.position = Camera.main.WorldToScreenPoint(
																		transform.position + Vector3.up * 2);
	}
	private void OnMouseExit()
	{
		gm.villianHealthMeterObject.SetActive(false);
		hover = false;
		setColorOnMouseState();
	}

    /* void OnTriggerEvent(Collider unit)
	{
		if(unit.gameObject.tag == "merryWords")
		{
			health -= 1;
		}
        if(health == 0)
        {
            Destroy(unit);
        }
	} */ 
}

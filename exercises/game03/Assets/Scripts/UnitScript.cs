using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    public bool selected = false;
	bool hover = false;

	public string name;
	public Sprite portrait;

	Color defautColor;
	public Color hoverColor;
	public Color selectedColor; 

	CharacterController cc;
	public Vector3 destination;

	public Renderer rend;

	GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
		//health = Random.Range(60,100);
        GameObject gmObj = GameObject.Find("GameManagerObject");
		gm = gmObj.GetComponent<GameManager>();

        cc = gameObject.GetComponent<CharacterController>();

        destination = transform.position;

        defautColor = rend.material.color;

		setColorOnMouseState();

        transform.eulerAngles = new Vector3(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null && Vector3.Distance(destination, transform.position) > 0.5f) 
        {
			destination.y = transform.position.y;
			Vector3 vecToDest = (destination - transform.position).normalized;
			float step = 3 * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, vecToDest, step, 1);
			transform.rotation = Quaternion.LookRotation(newDir);

			cc.Move(transform.forward * 5 * Time.deltaTime);
		}
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

	private void OnMouseOver()
	{
		hover = true;
		setColorOnMouseState();

		/* gm.healthMeterObject.SetActive(true);
		gm.meterFG.fillAmount = health / 100;
		gm.healthMeterObject.transform.position = Camera.main.WorldToScreenPoint(
																		transform.position + Vector3.up * 2); */
	}
	private void OnMouseExit()
	{
		gm.healthMeterObject.SetActive(false);

		hover = false;
		setColorOnMouseState();
	}
	private void OnMouseDown()
	{
		selected = !selected;
		if (selected) 
		{
			gm.selectUnit(this);
		} 
		else 
		{
			gm.selectUnit(null);
		}
		setColorOnMouseState();
	}
}

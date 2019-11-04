using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UnitScript selectedUnit;

    public GameObject talkBox;
	public Text talkText;
	public ToggleGroup actionSelectToggleGroup;
	public GameObject selectedPanel;
	public Text nameText;
	public Image portraitImage;

    public Image meterFG;
    public GameObject healthMeterObject;

	public Image villianMeter;
	public GameObject villianHealthMeterObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, 9999)) 
            {
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ground")) 
                {
					if (selectedUnit != null) 
                    {
						selectedUnit.destination = hit.point;
					}
				}
			} 
            else 
            {
				if (selectedUnit != null) 
                {
					selectedUnit.selected = false;
					selectedUnit.setColorOnMouseState();
					selectedUnit = null;

					updateSelectedPanelUI();
				}
			}
		}
	}

	public void selectUnit(UnitScript unit)
	{
		if(selectedUnit != null)
		{
			selectedUnit.selected = false;
			selectedUnit.setColorOnMouseState();
		}

		selectedUnit = unit;

		if(selectedUnit != null)
		{
			selectedUnit.selected = true;
			selectedUnit.setColorOnMouseState();
		}

		updateSelectedPanelUI();
	}

	void updateSelectedPanelUI()
	{
		if(selectedUnit != null)
		{
			nameText.text = selectedUnit.name;
			portraitImage.sprite = selectedUnit.portrait;
			selectedPanel.SetActive(true);
		}
		else
		{
			selectedPanel.SetActive(false);
		}
	}

	public void TakeAction()
	{
		Vector3 pos = selectedUnit.transform.position + Vector3.up * 2;
		pos = Camera.main.WorldToScreenPoint(pos);
		talkBox.transform.position = pos;

		IEnumerable<Toggle> activeToggles = actionSelectToggleGroup.ActiveToggles();
		string action = "";
		foreach(Toggle t in activeToggles)
		{
			if(t.IsActive())
			{
				action = t.gameObject.GetComponentInChildren<Text>().text;
			}
		}

		StartCoroutine(displayTalkBoxMessages(new string[] {action, "I'm done", "Actually, one more thing...", "Never mind..."}));
	}

	IEnumerator displayTalkBoxMessages(string[] messages)
	{
		talkBox.SetActive(true);
		for(int i = 0; i < messages.Length; i++)
		{
			talkText.text = messages[i];

			while(!Input.GetMouseButtonDown(0))
			{
				yield return null;
			}

			yield return null;
		}

		talkBox.SetActive(false);
	} 
}

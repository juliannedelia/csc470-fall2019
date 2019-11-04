using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleObjectScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* public void SelectedCharacter()
    {
        IEnumerable<Toggle> activeToggles = actionSelectToggleGroup.ActiveToggles();
		string action = "";
		foreach(Toggle t in activeToggles)
		{
			if(t.IsActive())
			{
				selectedCharacter = t.gameObject.GetComponentInChildren<Text>().text;
			}
		}
    } */
    
    public void PressStart()
    {
        SceneManager.LoadScene("game");
    }
}

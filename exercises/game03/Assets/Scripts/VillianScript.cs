using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillianScript : MonoBehaviour
{
    public string name;
	public Sprite portrait;

	public float health;

	Color defautColor;
	public Color hoverColor;
	public Color selectedColor; 

    public GameObject InsultPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position + Vector3.up * 0.5f + transform.forward * 0.5f;
        GameObject insult = Instantiate(InsultPrefab, pos, transform.rotation);
        Destroy(insult, 1);
    }

    /* void OnCollisionEnter(Collision unit)
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

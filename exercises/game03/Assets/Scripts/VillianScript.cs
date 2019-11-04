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
        StartCoroutine(DelayShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
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

    void OnTriggerEvent(Collider unit)
	{
		if(unit.gameObject.tag == "merryWords")
		{
			health -= 1;
		}
        if(health == 0)
        {
            Destroy(unit);
        }
	} 
}

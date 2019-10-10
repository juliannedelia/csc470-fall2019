using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool alive = false;
    public bool nextAlive;
    bool prevAlive;
    public int x = -1;
    public int y = -1;
    Renderer renderer;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //renderer = gameObject.GetComponent<Renderer>();
        prevAlive = alive;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prevAlive != alive)
        {
            updateColor();
            updateCubeSize();
        }
        prevAlive = alive;
    }

    public void updateColor()
    {
        if(renderer == null)
        {
            renderer = gameObject.GetComponent<Renderer>();
        }
        if(this.alive)
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.magenta;
        }
    }

    public void updateCubeSize()
    {
        if (alive) 
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(transform.localScale.y * 2, 5, 50), transform.localScale.z);
        } else 
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(transform.localScale.y / 2 , 5, 50), transform.localScale.z);
        }
    } 

    private void OnMouseDown()
    {
        alive = !alive;
        
    }
    
}

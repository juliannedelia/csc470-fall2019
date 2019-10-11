using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    public bool selected = false;
    public bool hover = false;
    Color defaultColor;
    public Color hoverColor;
    public Color selectedColor;

    public Vector3 destination;

    CharacterController cc;

    public Renderer renderer;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();
        cc.gameObject.GetComponent<CharacterController>();
        //renderer = gameObject.GetComponent<Renderer>();
        defaultColor = renderer.material.color;
        setColorOnMouseState();
    }

    // Update is called once per frame
    void Update()
    {
        if(destination != null && Vector3.Distance(destination, transform.position) > 1)
        {
            Vector3 vecToDest = (destination - transform.position).normalized;
            cc.Move(vecToDest * 5 * Time.deltaTime);
        }
        else
        {
            destination = transform.position;
        }
    }

    private void OnMouseOver()
    {
        hover = true;
        setColorOnMouseState();
    }

    private void OnMouseExit()
    {
        hover = false;
        setColorOnMouseState();   
    }

    private void OnMouseDown()
    {
        selected = !selected;
        if(selected)
        {
            gm.selectUnit(this);
        }
        setColorOnMouseState();
    }

    public void setColorOnMouseState()
    {
        if(selected)
        {
            renderer.material.color = selectedColor;
        }
        else if(hover)
        {
            renderer.material.color = hoverColor;
        }
        else
        {
            renderer.material.color = defaultColor;
        }
    }
}

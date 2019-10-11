using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    UnitScript selectedUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 9999))
            {
                selectedUnit.destination = hit.point;
            }
        }
    }

    public void selectUnit(UnitScript unit)
    {
        //GameObject[] units = GameObject.FindGameObjectsWithTag("unit");
        if(selectedUnit != null)
        {
            selectedUnit.selected = false;
            selectedUnit.setColorOnMouseState();
        }
        selectedUnit = unit;
        selectedUnit.selected = true;
        selectedUnit.setColorOnMouseState();
    }
}

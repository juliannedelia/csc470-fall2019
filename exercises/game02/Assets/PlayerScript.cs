using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController cc;

    float moveSpeed = 8;
    float rotateSpeed = 70;

    float yVel = 0;

    float jumpForce = 3;

    float gravityModifier = 0.05f;

    bool prevIsGrounded;

    public bool trig = true;


    // Start is called before the first frame update
    void Start()
    {
        //cc = gameObject.GetComponent<CharacterController>();
        prevIsGrounded = cc.isGrounded;
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        
        transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        Vector3 amountToMove = transform.forward * moveSpeed * Time.deltaTime * vAxis;

        if(cc.isGrounded)
        {
            if(!prevIsGrounded && cc.isGrounded)
            {
                yVel = 0;
            }
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                yVel = jumpForce;
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                yVel = 0;
            }
            yVel += Physics.gravity.y * gravityModifier;
        } 

        amountToMove.y = yVel;

        cc.Move(amountToMove);

        prevIsGrounded = cc.isGrounded;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cell"))
        {
            Debug.Log("entered");
            CellScript cs = other.gameObject.GetComponent<CellScript>();
            cs.alive = !cs.alive;
        }
    }
}

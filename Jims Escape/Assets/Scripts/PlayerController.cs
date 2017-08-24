using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    Animator anim;

    public bool isfacingFront = true;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();  
    }

    void Update()
    {

        //Listening for Inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (isfacingFront == true)
            {
                anim.Play("TurnLeft");
                isfacingFront = false;
            }
            else {
                anim.Play("WalkLeft");
            }
            

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            anim.Play("Walk");
                        
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.Play("Idle");
            isfacingFront = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.Play("IdleLeft");
        }

    }

}





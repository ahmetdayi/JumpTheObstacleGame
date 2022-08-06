using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private Rigidbody _playerRgbd;
    public float jumpForce =30f;
    public float gravityModifier;
    public bool isGround = true;
    public bool isGameOver = false;
    private Animator playerAnim;

   
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        _playerRgbd = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
    }

 

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isGameOver)
        {
            _playerRgbd.AddForce(Vector3.up*(jumpForce),ForceMode.Impulse);
            isGround = false;
            playerAnim.SetTrigger("Jump_trig");
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            Debug.Log("gameover");
        }
    }
}

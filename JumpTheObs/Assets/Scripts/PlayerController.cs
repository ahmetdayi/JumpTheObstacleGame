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
    public ParticleSystem explosionParticle;
    public ParticleSystem splatterParticle;
    public AudioSource voiceSource;
    public AudioClip[] voiceClip;


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
            splatterParticle.Stop();
            voiceSource.PlayOneShot(voiceClip[0]);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            splatterParticle.Play();
            
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            Debug.Log("gameover");
            explosionParticle.Play();
            splatterParticle.Stop();
            voiceSource.PlayOneShot(voiceClip[1]);
        }
    }
}

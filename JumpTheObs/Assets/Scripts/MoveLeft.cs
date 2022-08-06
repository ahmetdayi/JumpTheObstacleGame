using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    #region veriables

    public float speed = 20f;
    private PlayerController _playerControllerScript;
    private float leftBound = -15f;

    #endregion

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();

        if (transform.position.x < leftBound && CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (_playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
    }
}

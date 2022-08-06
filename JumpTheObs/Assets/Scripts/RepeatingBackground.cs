using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private Vector3 _startingPos;
    private float repeatWidth;
    void Start()
    {
        _startingPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x/2;//bu sayede backgroundun orta noktasını bulmus oluyoruz
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startingPos.x - repeatWidth)
        {
            transform.position = _startingPos;
        }
    }
}

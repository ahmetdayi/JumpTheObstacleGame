using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    #region veriables

    public GameObject obstaclePrefab;
    private Vector3 _spawnPosition =new Vector3(20,0,0);
    private float _startDelay = 2f;
    float _startInterval = 2f;
    private PlayerController _playerControllerScript;
    

    #endregion
    
    
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       
            InvokeRepeating("ProductObstacle",_startDelay,_startInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ProductObstacle()
    {
        if (_playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}

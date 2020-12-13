using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementTowardsScript : MonoBehaviour
{

    private bool isClicked = false;

    public float speed = 15.0f;

    public GameObject player;
    private Transform tPositionPlayer; 

    public GameObject tileToMove;
    private Transform target;


    // Start is called before the first frame update
    void Awake()
    {
        target = tileToMove.transform;
    }

    public void OnPointerClick()
    {
        Debug.Log("HOLA");
        tPositionPlayer = player.GetComponent<Transform>();
        target = tileToMove.GetComponent<Transform>();
        Debug.Log(tPositionPlayer.position);
        Debug.Log(target.position);
        float step = speed * Time.deltaTime;
        while (Math.Abs(player.transform.position.x - target.position.x)>2
            || Math.Abs(player.transform.position.z -target.position.z) > 2){
            player.transform.position = Vector3.MoveTowards(player.transform.position, target.position, step);
        }
        Debug.Log(player.transform.position);        
    }
}

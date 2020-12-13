using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClick : MonoBehaviour
{

    public GameObject gameObject;

    private bool isLooked = false;
    private float timerDuration =  3f;
    private float lookTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLooked){
            lookTimer += Time.deltaTime;

            if (lookTimer > timerDuration){
                lookTimer = 0f;
                OnPointerClick();
            }
        } else {
            lookTimer = 0f;
        }
    }

    public void setIsLooked(bool looked){
        isLooked = looked;
    }

    public void OnPointerClick(){
        String txt = "Hola";
    }
}

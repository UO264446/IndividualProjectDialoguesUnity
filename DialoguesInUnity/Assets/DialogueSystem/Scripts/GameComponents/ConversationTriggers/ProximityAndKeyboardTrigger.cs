using DialogueManager.GameComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ProximityAndKeyboardTrigger : MonoBehaviour
{
    public GameObject Tracked;
    private Transform tPosition;
    private bool wasTriggered = false;

    public GameObject Player;

    private Transform tPositionPlayer;

    // Start is called before the first frame update
    public void Start()
    {
        tPosition = Tracked.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
        tPosition = Tracked.GetComponent<Transform>();
        tPositionPlayer = Player.GetComponent<Transform>();
        if ( Input.GetKeyDown("space")  && ( tPositionPlayer.position.x < Math.Abs(tPosition.position.x + 2) && ( tPositionPlayer.position.z < Math.Abs(tPosition.position.z + 2))))
        {
            if (!wasTriggered)
            {
                wasTriggered = true;

                ConversationComponent conversation = this.GetComponent<ConversationComponent>();
                if (conversation != null)
                {
                    conversation.Trigger( );
                }
            }
        }
        else if (wasTriggered)
        {
            wasTriggered = false;
        }
    }
}
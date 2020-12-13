namespace DialogueManager.GameComponents.Triggers
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalTrigger : MonoBehaviour
{

    private bool wasTriggered = false;
    private int frames = 0;

    //va a haber que meeter alguna variable para indicar si el juego ha empezado o no...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frames == 1000){
            if (!wasTriggered)
                {
                    wasTriggered = true;

                    ConversationComponent conversation = this.GetComponent<ConversationComponent>();
                    if (conversation != null)
                    {
                        conversation.Trigger( );
                    }
                }
            frames = 0;
        }
        else if (wasTriggered)
        {
            wasTriggered = false;
        }
        frames++;
    }
}
}
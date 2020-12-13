namespace DialogueManager.GameComponents
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFrameTrigger : MonoBehaviour
{

    private bool wasTriggered = false;

    //va a haber que meeter alguna variable para indicar si el juego ha empezado o no...

    // Start is called before the first frame update
    void Start()
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
  
}
}
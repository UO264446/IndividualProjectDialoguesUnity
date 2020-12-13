using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager.GameComponents;

public class OnClickTrigger : MonoBehaviour
{

    public GameObject tracked;

    public ConversationComponent conversationComponent;

    private bool wasTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnPointerClick()
    {
        if (!wasTriggered)
            {
                wasTriggered = true;

                ConversationComponent conversation = conversationComponent;
                if (conversation != null)
                {
                    conversation.Trigger( );
                }
            }
        else if (wasTriggered)
        {
            wasTriggered = false;
        }
    }
}

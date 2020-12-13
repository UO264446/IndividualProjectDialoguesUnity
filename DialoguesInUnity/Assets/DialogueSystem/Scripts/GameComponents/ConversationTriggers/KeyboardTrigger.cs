namespace DialogueManager.GameComponents.Triggers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class KeyboardTrigger : MonoBehaviour
    {
        private bool wasTriggered = false;

        private void Start()
        {
        }

        private void Update()
        {
            if ( Input.GetKeyDown("space")   )
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
}
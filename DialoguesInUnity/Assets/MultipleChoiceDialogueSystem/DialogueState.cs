using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    //Keeps track of the state of the dialogue tree where we're pointing at
    public class DialogueState : MonoBehaviour
    {
        //Dictionary with the name of the character we're interacting with and the dialogue tree state
        public Dictionary<string, string> stateDictionary;

        private void Start(){
            stateDictionary = new Dictionary<string, string>();
        }
    }
}


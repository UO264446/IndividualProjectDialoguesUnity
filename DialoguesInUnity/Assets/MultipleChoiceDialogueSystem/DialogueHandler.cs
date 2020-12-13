using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.XR.WSA.Input;

namespace Dialogue
{

    public class DialogueHandler : AbstractInteractable
    {

        [SerializeField] private DialogueTreeObject dialogueTree;
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] private UnityEvent onDialogueEnd;
        [SerializeField] private ScriptableEvent[] scriptableEvents;

        private bool isLooked = false;
    private float timerDuration =  3f;
    private float lookTimer = 0f;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            dialogueTree.ResetCallbacks();
            foreach (var scriptableEvent in scriptableEvents){
                dialogueTree.RegisterScriptableCallback(scriptableEvent.eventName, () => scriptableEvent.unityEvent.Invoke());
            }
            dialogueTree.SetUpDialogueUnitDict();
            dialogueTree.continueCallback += dialogueUI.ContinueDialogue;
            dialogueTree.continueCallback += ContinueDialogue;
        }

        public void Update(){
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

        //public void OnInteract(AbstractInteractable interactable){
        public override void OnPointerClick(){//AbstractInteractable interactable){
            var dialogueState = GetComponent<DialogueState>(); //interactable.GetComponent<DialogueState>();
            if (dialogueState == null) return;

            dialogueTree.SetUpDialogueState(dialogueState);
            ContinueDialogue();
        }

        public void ContinueDialogue(){
            HandleDialogue(dialogueTree.GetNextDialogueUnit());
        }

        public void EndDialogue(){
            onDialogueEnd.Invoke();
        }

        private void HandleDialogue(DialogueUnit dialogueUnit){
            dialogueUI.SetNpcName(dialogueTree.npcName);
            dialogueUI.SetSentences(dialogueUnit.sentences);
            dialogueUI.SetDialogueOptions(dialogueUnit.options, dialogueTree.defaultOption);
            dialogueUI.ContinueDialogue();
        } 
    }

}


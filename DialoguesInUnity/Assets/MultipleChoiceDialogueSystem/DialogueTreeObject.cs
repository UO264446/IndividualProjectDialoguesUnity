using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueTree", menuName = "ScriptableObjects/Dialogue Tree")]
    public class DialogueTreeObject : ScriptableObject
    {
        public string npcName;
        public string defaultState;
        public DialogueOption defaultOption;
        public string[] scriptableCallbackNames;
        public DialogueUnit[] dialogueUnits;

        public DialogueState dialogueState;
        public Action continueCallback;
        public Action endDialogueCallback;
        public Dictionary<string, DialogueUnit> dialogueUnitDict;
        public Dictionary<string, Action> scriptableCallbacks = new Dictionary<string, Action>();


        public void AddToState(string stateToAdd){
            dialogueState.stateDictionary[npcName] += stateToAdd;
        }
 
        public void RemoveState(int length = 1){
            if (dialogueState.stateDictionary[npcName].Length < length)
            {
                return;
            }
            dialogueState.stateDictionary[npcName] = dialogueState.stateDictionary[npcName].Remove(dialogueState.stateDictionary[npcName].Length - length);
        }

        public void CallScriptableAction(string actionName){
            scriptableCallbacks[actionName]();
        }

        public void Continue(){
            continueCallback();
        }

        public void EndDialogue(){
            endDialogueCallback();
        }

        public void RegisterScriptableCallback(string callbackName, Action action){
            scriptableCallbacks[callbackName] = action;
        }

        public void SetUpDialogueUnitDict(){
            dialogueUnitDict = new Dictionary<string, DialogueUnit>();
            foreach (var dialogueUnit in dialogueUnits){
                dialogueUnitDict[dialogueUnit.requiredStateKey] = dialogueUnit;
            }
        }

        public void SetUpDialogueState(DialogueState state){
            dialogueState = state;
            if (!dialogueState.stateDictionary.ContainsKey(npcName)){
                dialogueState.stateDictionary[npcName] = defaultState;
            }
        }

        public void ResetCallbacks(){
            continueCallback = () => {};
            endDialogueCallback = () => {};
            scriptableCallbacks.Clear();
        }

        public DialogueUnit GetNextDialogueUnit(){
            return dialogueUnitDict.TryGetValue(dialogueState.stateDictionary[npcName], out var value) ? value : null;
        }
        
    }

}

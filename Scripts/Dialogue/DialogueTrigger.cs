using UnityEngine;

class DialogueTrigger : MonoBehaviour {
  public DialogueManager manager;
  public Dialogue dialogue;
  
  void TriggerDialogue() {
    manager.StartDialogue(dialogue);
  }
}

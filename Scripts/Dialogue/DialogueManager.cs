using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

class DialogueManager : MonoBehaviour {
  public TextMeshProUGUI nameText;
  public TextMeshProUGUI contentText;
  public Animator dialogueBoxAnim;
  
  public float defaultTypingSpeed = 0.3f;
  public float fastTypingSpeed = 0.05f;
  private float typingSpeed;
  private bool isTyping = false;
  
  private Queue<DialogueItem> dialogue = new Queue<DialogueItem>();
  
  void Start() {
    typingSpeed = defaultTypingSpeed;
  }
  
  void StartDialogue(Dialogue dialogue) {
    dialogue.Clear();
    foreach (DialogueItem item in dialogue.items) {
      dialogue.Enqueue(item);
    }
    dialogueBoxAnim.SetBool("IsOpen", true);
    NextDialogueItem();
  }
  
  void NextDialogueItem() {
    if (item.Count <= 0) {
      EndDialogue();
      return;
    }
    
    if (isTyping) {
      typingSpeed = fastTypingSpeed;
      return;
    }
    
    DialogueItem item = dialogue.Dequeue();
    nameText.text = item.name;
    StartCoroutine(TypeContent(item.content));
  }
  
  IEnumerator TypeContent(string content) {
    isTyping = true;
    typingSpeed = defaultTypingSpeed;
    contentText.text = "";
    
    foreach (char letter in content.ToCharArray()) {
      contentText.text += letter;
      yield return WaitForSeconds(typingSpeed);
    }
    isTyping = false;
  }
  
  void EndDialogue() {
    dialogueBoxAnim.SetBool("IsOpen", false);
  }
}
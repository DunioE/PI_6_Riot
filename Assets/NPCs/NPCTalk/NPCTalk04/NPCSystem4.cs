using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem4 : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    public Animator animator;
    public static bool dialogueInProgress = false;

    bool playerDetection = false;

    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.F) && !dialogueInProgress)
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        animator.SetBool("isTalking", true);

        NewDialogue("teste do 4");
        NewDialogue("isto é outro teste");
        canva.transform.GetChild(1).gameObject.SetActive(true);
        dialogueInProgress = true;
    }

    void EndDialogue()
    {
        DestroyDialogue(); // Adiciona essa linha
        dialogueInProgress = false;

        animator.SetBool("isTalking", false);
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, canva.transform);
        template_clone.tag = "D_TemplateClone"; // Adicione esta linha
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    void DestroyDialogue()
    {
        // Destruir todos os clones do D_Template
        foreach (Transform child in canva.transform)
        {
            if (child.CompareTag("D_TemplateClone")) // Adicione esta tag ao D_Template no Inspector
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetection = false;
        EndDialogue(); // Modifica aqui
    }
}

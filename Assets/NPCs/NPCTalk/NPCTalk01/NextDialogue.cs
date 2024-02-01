using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    int index = 0;
    bool canClick = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick && transform.childCount > 0)
        {
            // Desativar o clone atual do D_Template
            GameObject currentDialogue = transform.GetChild(index).gameObject;
            if (currentDialogue != null)
            {
                currentDialogue.SetActive(false);
            }

            index += 1;

            if (index >= transform.childCount)
            {
                index = 0;
                NPCSystem.dialogueInProgress = false;

                // Desativar o Canva ap�s o t�rmino do di�logo (opcional)
                if (transform.parent != null)
                {
                    transform.parent.gameObject.SetActive(false);
                }
            }
            else
            {
                // Ativar o pr�ximo clone do D_Template para exibir o pr�ximo di�logo
                GameObject nextDialogue = transform.GetChild(index).gameObject;
                if (nextDialogue != null)
                {
                    nextDialogue.SetActive(true);
                }
            }

            StartCoroutine(ResetClick());
        }
    }

    IEnumerator ResetClick()
    {
        canClick = false;
        yield return new WaitForSeconds(0.2f); // Ajuste o tempo conforme necess�rio
        canClick = true;
    }
}

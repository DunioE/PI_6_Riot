using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguicaoFugaNPC : MonoBehaviour
{
    public GameObject objetoParaApagar;
    public Canvas canvasParaAtivar;
    public float tempoParaDestruirCanvas = 5f; // Ajuste conforme necess�rio

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(objetoParaApagar);

            if (canvasParaAtivar != null)
            {
                canvasParaAtivar.gameObject.SetActive(true);

                Destroy(canvasParaAtivar.gameObject, tempoParaDestruirCanvas);
            }
        }
    }
}

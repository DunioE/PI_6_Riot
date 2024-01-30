using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoVFX : MonoBehaviour
{
    public GameObject efeitoPrefab;
    public string[] tagsAlvo; 
    public float alturaEfeito = 1.0f; 
    public float duracaoEfeito = 3.0f; 

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("EspadaVFX"))
        {
            foreach (string tagAlvo in tagsAlvo)
            {
                if (other.CompareTag(tagAlvo))
                {
                    SpawnEfeito(other.transform.position);
                    break; 
                }
            }
        }
    }

    private void SpawnEfeito(Vector3 spawnPosition)
    {
        if (efeitoPrefab != null)
        {
           
            spawnPosition += new Vector3(0f, alturaEfeito, 0f);

            GameObject efeitoInstancia = Instantiate(efeitoPrefab, spawnPosition, Quaternion.identity);

            Destroy(efeitoInstancia, duracaoEfeito);

        }
        else
        {
            Debug.LogError("Prefab de efeito não atribuído ao script!");
        }
    }
}

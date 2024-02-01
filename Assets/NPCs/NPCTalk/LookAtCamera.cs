using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Mantém a rotação olhando para a câmera
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); // Ajusta a rotação para ficar alinhada corretamente
    }
}

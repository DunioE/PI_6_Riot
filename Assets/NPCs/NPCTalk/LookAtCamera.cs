using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Mant�m a rota��o olhando para a c�mera
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); // Ajusta a rota��o para ficar alinhada corretamente
    }
}

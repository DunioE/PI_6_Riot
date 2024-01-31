using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaController : MonoBehaviour
{
    public float tempoParaAtivar = 5.0f; // Tempo para ativar a chuva
    public float duracaoChuva = 10.0f; // Tempo que a chuva permanecerá ativa

    // Referência para o Particle System
    public ParticleSystem particleSystem;

    private bool chuvaAtiva = false;
    private float tempoPassado = 0.0f;

    void Start()
    {
        // Garante que o Particle System não está reproduzindo inicialmente
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
        else
        {
            Debug.LogError("Particle System não atribuído! Atribua um Particle System no Editor do Unity.");
        }
    }

    void Update()
    {
        // Se a chuva não estiver ativa, contabiliza o tempo até ativar
        if (!chuvaAtiva)
        {
            tempoPassado += Time.deltaTime;

            // Se o tempo passado atingir o tempo para ativar, ativa a chuva
            if (tempoPassado >= tempoParaAtivar)
            {
                AtivarChuva();
            }
        }
        else
        {
            // Se a chuva estiver ativa, contabiliza o tempo de duração
            tempoPassado += Time.deltaTime;

            // Se o tempo passado atingir o tempo de duração, desativa a chuva e reinicia o ciclo
            if (tempoPassado >= duracaoChuva)
            {
                DesativarChuva();
            }
        }
    }

    void AtivarChuva()
    {
        // Ativa o Particle System
        particleSystem.Play();

        // Reseta o tempo passado e marca a chuva como ativa
        tempoPassado = 0.0f;
        chuvaAtiva = true;
    }

    void DesativarChuva()
    {
        // Para o Particle System
        particleSystem.Stop();

        // Reseta o tempo passado e marca a chuva como não ativa
        tempoPassado = 0.0f;
        chuvaAtiva = false;
    }
}
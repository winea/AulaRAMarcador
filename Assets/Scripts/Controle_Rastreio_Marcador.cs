using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// Esse Script foi modificado a partir do Script: DefaultTrackableEventHandler (Assets -> Vuforia -> Scripts). Foi preciso essa modificação para que os objetos em cena (associados ao marcador) só fossem ativados somente quando o marcador é encontraro pela câmera real, senão a física e outras propriedades podem ser acionadas no horário errado, causando problemas.

public class Controle_Rastreio_Marcador : MonoBehaviour,
ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }


    // Essa função é chamada cada vez que o estado da rastreio é modificado. É utilizado para decidir o que fazer quando o marcador é encontrado (detected), rastreado continuamente (tracked), rastreio com o uso do ambiente (extended_tracked) e deixa de ser encontrado (On Tracking Lost)

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        // Marcador encontrado
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }

        // Marcador deixa de ser encontrado
        else
        {
            OnTrackingLost();
        }
    }

    // Quando o marcador é encontrado
    private void OnTrackingFound()
    {
        // Lista de components a ser renderizado nos filhos
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        // Lista de components de colisões nos filhos
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        // Percorre os filhos deste GameObject, ativando cada um
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Debug.Log("Ativando os filhos");
            this.transform.GetChild(i).gameObject.SetActive(true);
        }

        // Ativa a renderização
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Ativa as colisões
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        Debug.Log("Rastreamento de " + mTrackableBehaviour.TrackableName + " encontrado");
    }

    // Quando o marcador para de ser encontrado
    private void OnTrackingLost()
    {
        // Lista de components a ser renderizado nos filhos
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        // Lista de components de colisões nos filhos
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        // Percorre os filhos deste GameObject, desativando cada um
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Debug.Log("Desativando os filhos");
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Desativa a renderização
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Desativa as colisões
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Rastreamento de " + mTrackableBehaviour.TrackableName + " perdido");
    }
}



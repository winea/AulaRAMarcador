using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

//saber se o marcador foi detectado para habilitar a renderização
public class Controle_Rastreio_Marcador : MonoBehaviour {
    ITrackableEventHandler{

        private TrackableBehaviour mTrackableBehaviour;

    // Use this for initialization
    void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        } else
        {
            OnTrackingLost();
        }

    }

    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentInChildren<Renderer>();

        Collider[] colliderComponents = GetComponentInChildren<Collider>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Debug.Log("Ativando Filhos");
            this.transform.GetChild(i).gameObject.SetActive(true);
        }

        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }
        Debug.Log("Rastreamento de " + mTrackableBehaviour.TrackableName + "encontrado")
    }

    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentInChildren<Renderer>();

        Collider[] colliderComponents = GetComponentInChildren<Collider>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Debug.Log("Desativando os Filhos");
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Rastreamento de" + mTrackableBehaviour.TrackableName + "perdido");
    }
}

}

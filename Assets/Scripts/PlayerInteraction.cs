using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public NPC logicaNPC;
    public Transform startPosition;
    public Camera cam1;
    public Camera cam2;

    private void Update() {

        // Cambio de cámara
        if (Input.GetKeyDown(KeyCode.C)) {
            if (cam1.gameObject.activeSelf) {
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(true);
            } else {
                if (cam2.gameObject.activeSelf) {
                    cam2.gameObject.SetActive(false);
                    cam1.gameObject.SetActive(true);  
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {

        // Si atrapamos un conejo
        if (collision.gameObject.CompareTag("Conejo")) {
            logicaNPC.numeroObjetivos--;
            logicaNPC.textoMision.text = "Conejos restantes: " + logicaNPC.numeroObjetivos;
            collision.gameObject.SetActive(false);
        }

        // Si no quedan más conejos
        if (logicaNPC.numeroObjetivos <= 0) {
            logicaNPC.textoMision.text = "Objetivo cumplido";
            logicaNPC.botonDeMision.SetActive(true);
        }

        // Si nos salimos del mapa
        if (collision.gameObject.CompareTag("PlanoFinal")) {
            //GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startPosition.position;
            //GetComponent<CharacterController>().enabled = true;
        }
    }
}

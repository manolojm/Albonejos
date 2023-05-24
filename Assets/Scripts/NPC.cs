using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class NPC : MonoBehaviour {
    public GameObject simboloMision;
    public PlayerMove playerController;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject conejos;
    public GameObject[] objetivos;
    public int numeroObjetivos;
    public GameObject botonDeMision;


    // Start is called before the first frame update
    void Start() {
        numeroObjetivos = objetivos.Length;
        textoMision.text = "Conejos restantes: " + numeroObjetivos;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        simboloMision.SetActive(true);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && !aceptarMision) {
            Vector3 posicionPlayer = new Vector3(transform.position.x,
                playerController.gameObject.transform.position.y, transform.position.z);

            playerController.gameObject.transform.LookAt(posicionPlayer);
            playerController.animator.SetFloat("VelX", 0);
            playerController.animator.SetFloat("VelY", 0);
            playerController.enabled = false;

            panel2.SetActive(false);
            panel3.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            jugadorCerca = true;
            if (!aceptarMision) {
                panel2.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player" && aceptarMision) {
            jugadorCerca = false;
            panel2.SetActive(false);
            panel1.SetActive(true);
        } else {
            panel2.SetActive(false);
            panel3.SetActive(false);
        }
    }

    public void No() {
        playerController.enabled = true;
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    public void Si() {
        conejos.SetActive(true);
        playerController.enabled = true;
        aceptarMision = true;

        for (int i = 0; i < objetivos.Length; i++) {
            objetivos[i].SetActive(true);
        }

        jugadorCerca = false;
        simboloMision.SetActive(false);

        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

}

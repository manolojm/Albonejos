using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public void CargarMenu() {
        SceneManager.LoadScene("EscenaMenu");
   }

    public void CargaAyuda() {
        SceneManager.LoadScene("EscenaAyuda");
    }

    public void CargarSalir() {
        Application.Quit();
    }

    public void CargarEscena1() {
        SceneManager.LoadScene("Escena1");
    }

    public void CargarEscena2() {
        SceneManager.LoadScene("Escena2");
    }

    public void CargarCreditos() {
        SceneManager.LoadScene("EscenaCreditos");
    }

}

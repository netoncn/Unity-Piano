using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTeclado : MonoBehaviour {

    public AudioSource[] teclas;
    public AudioClip[] sons;

    public int indice = 0;

    public void MudarSom(int _indice) {
        foreach (AudioSource cadaAudio in teclas) {
            cadaAudio.clip = sons[_indice];
        }
    }

    public void Sair() {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeclaClass : MonoBehaviour {

    public float pitch;
    public bool _up;

    void OnMouseUp() {
        _up = true;
        GameObject.Find("Controlador").GetComponent<ControladorMouse>().ReturnKey(this.gameObject);
    }

}

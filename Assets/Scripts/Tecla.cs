using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla : MonoBehaviour {

    public float pitch;
    private AudioSource audio;

    public float velocity = 0.005f;
    private bool _up = false;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void OnMouseDown() {
        audio.pitch = pitch;
        audio.Play();
        RotateKey();
    }

    void OnMouseUp() {
        _up = true;
        StartCoroutine(RotateMe(Vector3.right * 4, velocity));
    }

    public void RotateKey() {
        StartCoroutine(RotateMe(Vector3.left * 4, velocity));
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime) {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t <= 1; t += inTime) {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        if (_up) {
            this.transform.rotation = Quaternion.identity;
            _up = false;
        }
    }
}

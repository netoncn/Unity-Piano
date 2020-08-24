using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMouse : MonoBehaviour {

    public float velocity = 0.7f;

    private float maxYCamera = 22f;
    private float maxZCamera = 28f;
    private float minYCamera = 5.40f;
    private float minZCamera = 7.30f;

    void Update() {

/*
        if (Input.touchCount > 0) {

            for (var i = 0; i < Input.touchCount; ++i) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    // Construct a ray from the current touch coordinates
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hitInfo;
                    // Create a particle if hit
                    if (Physics.Raycast(ray, out hitInfo)) {
                        GameObject hitObject = hitInfo.collider.gameObject;

                        if(hitObject.CompareTag("Key")){
                            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                                keyPlay(hitObject);
                            }
                        }
                    }
                }
            }
        }
        */

    }

    private void keyPlay(GameObject hitObject) {
        hitObject.GetComponent<AudioSource>().pitch = hitObject.GetComponent<TeclaClass>().pitch;
        hitObject.GetComponent<AudioSource>().Play();
        RotateKey(hitObject);
    }

    public void RotateKey(GameObject hitObject) {
        StartCoroutine(RotateMe(hitObject, Vector3.left * 4, velocity));
    }

    public void ReturnKey(GameObject hitObject) {
        StartCoroutine(RotateMe(hitObject, Vector3.right * 4, velocity));
    }

    IEnumerator RotateMe(GameObject hitObject, Vector3 byAngles, float inTime) {
        var fromAngle = hitObject.transform.rotation;
        var toAngle = Quaternion.Euler(hitObject.transform.eulerAngles + byAngles);
        for(var t = 0f; t <= 1; t += inTime) {
            hitObject.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        if (hitObject.GetComponent<TeclaClass>()._up) {
            hitObject.transform.rotation = Quaternion.identity;
            hitObject.GetComponent<TeclaClass>()._up = false;
        }
    }

}

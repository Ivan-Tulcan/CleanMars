using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamion : MonoBehaviour
{
    public float velocidad = 10f; // La velocidad a la que se mover� el cami�n.
    public float rotacionVelocidad = 100f; // La velocidad a la que el cami�n rotar�.

    void Update()
    {
        float movimientoVertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime * (-1);
        float movimientoHorizontal = Input.GetAxis("Horizontal") * rotacionVelocidad * Time.deltaTime;

        transform.Translate(Vector3.forward * movimientoVertical);
        transform.Rotate(Vector3.up * movimientoHorizontal);
    }

    
}

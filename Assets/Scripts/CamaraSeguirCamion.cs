using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguirCamion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camion; // El cami�n que la c�mara debe seguir.
    public float altura = 2f; // La altura de la c�mara.
    public float distancia = 6f; // La distancia de la c�mara.

    void LateUpdate()
    {
        try
        {
            Vector3 posicionCamion = camion.transform.position;
            Vector3 posicionCamara = new Vector3(posicionCamion.x, posicionCamion.y + altura, posicionCamion.z - distancia);
            transform.position = posicionCamara;
            transform.LookAt(posicionCamion);
        }
        catch (UnassignedReferenceException ex)
        {
        }

    }
}

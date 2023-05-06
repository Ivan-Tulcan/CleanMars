using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificarTamano : MonoBehaviour
{
    public float crecerRatio = 0.05f; // Porcentaje de crecimiento por colisi�n
    public float decrecerRatio = 0.03f; // Porcentaje de reducci�n por segundo
    public float decrecerEspera = 1.0f; // Retraso antes de comenzar a encogerse
    public float tamanoMaximo = 3f; // M�ximo factor de escala permitido
    public float decrecerTimer = 0.0f; // Tiempo transcurrido desde que comenz� a encogerse
    public bool estaDecreciendo = false; // Si el veh�culo se est� encogiendo

    private Vector3 escalaOriginal; // Escala original del veh�culo

    private void Start()
    {
        escalaOriginal = transform.localScale;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BotellaVidrio")|| other.gameObject.CompareTag("PapelCarton")|| other.gameObject.CompareTag("LataMetal"))
        {
            // Aumentar el tama�o del veh�culo en crecerRatio%
            transform.localScale += escalaOriginal * crecerRatio;

            // Limitar el tama�o m�ximo del veh�culo
            float scaleFactor = transform.localScale.x / escalaOriginal.x;
            if (scaleFactor > tamanoMaximo)
            {
                transform.localScale = escalaOriginal * tamanoMaximo;
            }
        }
    }

    private void Update()
    {
        if (!estaDecreciendo)
        {
            // Esperar el retraso antes de comenzar a encogerse
            decrecerTimer += Time.deltaTime;
            if (decrecerTimer >= decrecerEspera)
            {
                estaDecreciendo = true;
            }
        }
        else
        {
            // Reducir el tama�o del veh�culo en decrecerRatio% por segundo
            transform.localScale -= escalaOriginal * decrecerRatio * Time.deltaTime;
            if (transform.localScale.x <= escalaOriginal.x)
            {
                // Restablecer el tama�o original del veh�culo
                transform.localScale = escalaOriginal;
                estaDecreciendo = false;
                decrecerTimer = 0.0f;
            }
        }

    }
}

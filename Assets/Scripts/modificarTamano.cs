using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificarTamano : MonoBehaviour
{
    public float crecerRatio = 0.05f; // Porcentaje de crecimiento por colisión
    public float decrecerRatio = 0.03f; // Porcentaje de reducción por segundo
    public float decrecerEspera = 1.0f; // Retraso antes de comenzar a encogerse
    public float tamanoMaximo = 3f; // Máximo factor de escala permitido
    public float decrecerTimer = 0.0f; // Tiempo transcurrido desde que comenzó a encogerse
    public bool estaDecreciendo = false; // Si el vehículo se está encogiendo

    private Vector3 escalaOriginal; // Escala original del vehículo

    private void Start()
    {
        escalaOriginal = transform.localScale;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BotellaVidrio")|| other.gameObject.CompareTag("PapelCarton")|| other.gameObject.CompareTag("LataMetal"))
        {
            // Aumentar el tamaño del vehículo en crecerRatio%
            transform.localScale += escalaOriginal * crecerRatio;

            // Limitar el tamaño máximo del vehículo
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
            // Reducir el tamaño del vehículo en decrecerRatio% por segundo
            transform.localScale -= escalaOriginal * decrecerRatio * Time.deltaTime;
            if (transform.localScale.x <= escalaOriginal.x)
            {
                // Restablecer el tamaño original del vehículo
                transform.localScale = escalaOriginal;
                estaDecreciendo = false;
                decrecerTimer = 0.0f;
            }
        }

    }
}

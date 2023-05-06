using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecolectarBasura : MonoBehaviour
{
    string tipoBasura ="";
    
    

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Soda Can Red Variant") || child.name.Contains("ToiletPaper2 Variant") || child.name.Contains("Bottle4 (1) Variant"))
            { 
                child.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BotellaVidrio") || other.gameObject.CompareTag("PapelCarton") || other.gameObject.CompareTag("LataMetal"))
        {
            tipoBasura = other.gameObject.tag; //Se guarda el tipo de basura que se recolecto
            other.gameObject.SetActive(false); //Se desactiva el objeto de basura para que no se vea
            VariablesGlobales.basuraEnCola.Push(tipoBasura); //Se agrega el tipo de basura al stack
            Debug.Log("Basura recolectada: " + tipoBasura); //Se muestra en consola el tipo de basura que se recolecto (solo para pruebas)
            //MostrarUltimaBasura(tipoBasura); //Se muestra la ultima basura que se agrego al stack encima del camion
            VariablesGlobales.cantidadBasura -= 1; //Se resta 1 a la cantidad de basura que hay en el piso.
            VariablesGlobales.tipoBasura = tipoBasura; //Se guarda el tipo de basura que se recolecto en la variable global del tipo de basura actual
        }
    }

    /*
    public void MostrarUltimaBasura(string tipoBasuraRecolectada)
    {
        switch (tipoBasuraRecolectada)
        {
            case "BotellaVidrio":
                ActivarRepresentante("Bottle4 (1) Variant");
                break;
            case "PapelCarton":
                ActivarRepresentante("ToiletPaper2 Variant");
                break;
            case "LataMetal":
                ActivarRepresentante("Soda Can Red Variant");
                break;
            default:
                Debug.Log("No se reconoce el tipo de basura");
                break;
        }
    }

    public void ActivarRepresentante(string nombreBasura)
    {
        foreach (Transform child in transform)
        {
            if (child == null)
            {
                Debug.Log("No se encontro el objeto> " + child.name);
            }

            if (child.name.Contains(nombreBasura))
            { 
                child.gameObject.SetActive(true);
            }
            else if(child.name.Contains("Bottle4 (1) Variant") || child.name.Contains("ToiletPaper2 Variant") || child.name.Contains("Soda Can Red Variant"))
            {
                child.gameObject.SetActive(false);
            }          
            
        }
    }*/
}

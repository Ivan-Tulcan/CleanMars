using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesGlobales : MonoBehaviour
{
    public static int cantidadBasura; //La cantidad de basura en el mapa
    public static string tipoBasura; //El tipo de basura que se recogio al ultimo
    public static int vidaCamion; //La vida del camion
    public static int capacidadBasura; //La capacidad de basura del camion
    public static int basuraRecogida; //La cantidad de basura recogida
    public static int metalDepositado;  //La cantidad de metal depositado
    public static int papelDepositado;  //La cantidad de papel depositado
    public static int vidrioDepositado; //La cantidad de vidrio depositado
    public static bool estaDepositando; //Si el camion esta depositando o no
    public static int depositosFallidos; //La cantidad de depositos fallidos
    public static Stack<string> basuraEnCola ; //La basura que se ha recogido
    public static GameObject camion; //El camion
    
    // Start is called before the first frame update
    void Start()
    {
        cantidadBasura = 0;
        tipoBasura = "Vacio";
        vidaCamion = 100;
        capacidadBasura = 100;
        basuraRecogida = 0;
        metalDepositado = 0;
        papelDepositado = 0;
        vidrioDepositado = 0;
        estaDepositando = false;
        depositosFallidos = 0;

        camion = GameObject.Find("Garbage_Truck");
        basuraEnCola = new Stack<string>();
    }

    // Update is called once per frame
    void Update()
    {
        //imprimir en consola la cantidadBasura cada 5 segundos
        if (Time.frameCount % 300 == 0)
        {
            Debug.Log("Cantidad de basura: " + cantidadBasura);
        }
        if(basuraEnCola.Count > 0)
        {
            MostrarUltimaBasura(basuraEnCola.Peek());
        }
        else
        {
            ActivarRepresentante("vacio");
        }
        

    }

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
                ActivarRepresentante("vacio");
                Debug.Log("No se reconoce el tipo de basura");
                break;
        }
    }

    public void ActivarRepresentante(string nombreBasura)
    {
        foreach (Transform child in camion.transform)
        {

            if (child.name.Contains(nombreBasura))
            {
                child.gameObject.SetActive(true);
            }
            else if (child.name.Contains("Bottle4 (1) Variant") || child.name.Contains("ToiletPaper2 Variant") || child.name.Contains("Soda Can Red Variant"))
            {
                child.gameObject.SetActive(false);
            }

        }
    }



}

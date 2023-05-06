using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositaMetal : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Click en depositar metal");
        if (VariablesGlobales.tipoBasura == "LataMetal")
        {
            VariablesGlobales.basuraEnCola.Pop();
            if (VariablesGlobales.basuraEnCola.Count == 0)
            {
                VariablesGlobales.tipoBasura = "Vacio";
            }
            else
            {
                VariablesGlobales.tipoBasura = VariablesGlobales.basuraEnCola.Peek();
            }
            VariablesGlobales.metalDepositado++;
        }
    }
}
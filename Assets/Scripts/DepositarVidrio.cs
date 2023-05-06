using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositarVidrio : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Click en depositar vidrio");
        if (VariablesGlobales.tipoBasura == "BotellaVidrio")
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
            VariablesGlobales.vidrioDepositado++;
        }
    }
}

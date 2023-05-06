using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositarPapel : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Click en depositar papel");
        if (VariablesGlobales.tipoBasura == "PapelCarton" )
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
            VariablesGlobales.papelDepositado++;
        }
    }
}
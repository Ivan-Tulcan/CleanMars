using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraSpawner : MonoBehaviour
{
    public GameObject basuraMetal;
    public GameObject basuraPapel;
    public GameObject basuraVidrio;
    public int indiceTipoBasura;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            indiceTipoBasura = Random.Range(1, 4);
            switch (indiceTipoBasura)
            {
                case 1: //Para metal
                    Instantiate(basuraMetal, new Vector3(Random.Range(-24, 11), 0, Random.Range(-10, 25)), Quaternion.identity);
                    break;
                case 2: //Para papel
                    Instantiate(basuraPapel, new Vector3(Random.Range(-13, 21), 0, Random.Range(-19, 18)), Quaternion.identity);
                    break;
                case 3: //Para vidrio
                    Instantiate(basuraVidrio, new Vector3(Random.Range(-26, 8), 0, Random.Range(-6, 29)), Quaternion.identity);
                    break;
                default:
                    break;
            }
            VariablesGlobales.cantidadBasura += 10;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
}

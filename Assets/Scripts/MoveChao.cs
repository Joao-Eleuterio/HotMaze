using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChao : MonoBehaviour
{
    [SerializeField]
    Transform pontoInicial; //porta fechada
    [SerializeField]
    Transform pontoFinal; //porta aberta
    public float inc= 1; //porta sobe e desce
    public bool X_Z;
   
    void Start()
    {
        //ponto inicial
        transform.position = pontoInicial.position;
    }
    void Update()
    {  
        Vector3 novaPosicao = transform.position;
        if (X_Z == true)
            novaPosicao.x -= inc * Time.deltaTime;
        else
           novaPosicao.z -= inc * Time.deltaTime;
        transform.position = novaPosicao;
        //verificar se ja fechou/abriu
        if (inc > 0)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoFinal.position)) < 0.1)
                inc *= -1;
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoInicial.position)) < 0.1)
                inc *= -1;
        }
    }
}

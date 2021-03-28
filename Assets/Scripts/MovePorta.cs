using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePorta : MonoBehaviour
{
    [SerializeField]
    Transform pontoInicial; //porta fechada
    [SerializeField]
    Transform pontoFinal; //porta aberta
    public float incY; //porta sobe e desce
    public BoxCollider _box;
    void Start()
    {
        //ponto inicial
        transform.position = pontoInicial.position;
    }
    private void Update()
    {
        if (_box.tag.Equals("jaula3" ))
        {
            if (incY < 0)
              this.enabled = false;
            incY = 1;
        }
        if (_box.tag.Equals("jaula1") || _box.tag.Equals("jaula2"))
        {   
            if (incY > 0)
                this.enabled = false;
            incY = -1;
        }
        if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
        { 
            if (_box.tag.Equals("jaula4"))
            {
                if (incY > 0)
                    this.enabled = false;
                incY = -1;
            }
        }
            Vector3 novaPosicao = transform.position;
        novaPosicao.y += incY *Time.deltaTime;
        transform.position = novaPosicao;
        //verificar se ja fechou/ abriu
        if (incY < 0)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoFinal.position)) < 0.1)
                incY *= -1;
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoFinal.position)) < 0.1)
                incY *= -1;
        }
    }
}

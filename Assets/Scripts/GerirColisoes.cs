using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerirColisoes : MonoBehaviour
{
    [SerializeField]
    int tiraVida = 10;
    [SerializeField]
    float Intervalo = 3;
    [SerializeField]
    float ultimaVezQuePerdeuVida = 0;

    private void OnTriggerEnter(Collider other)
    { RetirarVida(other); }
    private void OnTriggerStay(Collider other)
    {
        if (ultimaVezQuePerdeuVida + Intervalo < Time.time)
        { RetirarVida(other); }
    }
    public void RetirarVida(Collider other)
    {
        //verifica que o GameObject que colidiu tem a componente Saude
        var temp = other.transform.GetComponent<Vida>() as Vida;
        //se sim retirar o valor correspondente de vida
        if (temp != null)
        {
            temp.retiraVida(tiraVida);
            ultimaVezQuePerdeuVida = Time.time;
        }
    }
}

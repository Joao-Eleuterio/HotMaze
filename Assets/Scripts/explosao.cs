using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour
{
    public float raioExplosao = 4.0f;
    public float forcaExplosao = 10.0f;
    public int danoBomba = 50;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("Explode", 3);
    }

    public void Explode()
    {
        //toca o som
        _audioSource.Play();
        Debug.Log("Explode");
        Vector3 posicaoExplosao = transform.position;
        //colecao dos colliders dentro do raio da explosao
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, raioExplosao);
        //para cada collider
        foreach (Collider obj in colliders)
        {
            if (obj is CharacterController) continue; //para evitar tirar duas vezes a vida ao player
            //se tem Rigidbody
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(forcaExplosao, posicaoExplosao, raioExplosao, 3.0f);
            //se tem componente de saude perde vida
            Vida pl = obj.GetComponent<Vida>();
            if (pl != null)
            {
                Debug.Log(pl.name + " " + rb.name);
                pl.retiraVida(danoBomba);
            }
        }
        //esconde a bola explosiva
        this.GetComponentInChildren<Renderer>().enabled = false;
        Destroy(this.gameObject, 3);
    }
}

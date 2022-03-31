using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Atirar_granada : MonoBehaviour
{
    public int granadas;
    public GameObject _modeloBola;
    public Transform _pontoAtirar;
    public float forcaAtirar = 5;

    void Start()
    { if(SceneManager.GetActiveScene().name.Equals("Nivel2") || SceneManager.GetActiveScene().name.Equals("Nivel3" ))
        {
            granadas = PlayerPrefs.GetInt("Granadas");
        }

    }
    void Update()
    {
        
        if (granadas != 0)
        {
            //atirar com 'Q'
            if (Input.GetButtonDown("Q"))
            {
               
                var objeto = Instantiate(_modeloBola, _pontoAtirar.position, Quaternion.identity);
                objeto.GetComponent<Rigidbody>().AddForce(transform.forward * forcaAtirar);
                granadas--;               
            }
        }
    }
    public int GetGranada()
    { return granadas;}
    public void AddGranada(int valor)
    {  granadas += valor; }
}

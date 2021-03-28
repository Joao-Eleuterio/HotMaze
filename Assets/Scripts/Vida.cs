using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField]
    int vida;
    [SerializeField]
    AudioClip _som;
    AudioSource _audioSource;
    Camera _cam;
    GameManager _gameManager;
    public Text mira;
    bool frst = true;
   
    private void Start()
    {
        if (gameObject.tag.Equals("Player"))
        { mira = GameObject.FindGameObjectWithTag("mira").GetComponent<Text>();  } 
        _gameManager = FindObjectOfType<GameManager>();   
        _audioSource = GetComponent<AudioSource>();
        _cam = GameObject.FindGameObjectWithTag("OldMainCamera").GetComponent<Camera>();
        _cam.enabled = false;

        if (frst == true && SceneManager.GetActiveScene().buildIndex > 3)
        {
            vida = PlayerPrefs.GetInt("Vida",100);
            frst = false;
        }
        if (frst == true && SceneManager.GetActiveScene().name.Equals("Nivel1"))
        {
           vida = 100;
            frst = false;
        }
    }
    public int GetVida()
    { return vida; }
    public void retiraVida(int valor)
    {
        vida -= valor;
        Debug.Log("Perdi " + valor + " de vida, só tenho " + vida);
        if (vida < 0)
            vida = 0;
        if (_audioSource != null)
        {
            _audioSource.clip = _som;
            _audioSource.Play();
        }
    }
    public void adicionaVida(int valor)
    { vida += valor; }
    private void Update()
    {
        if (vida <= 0)
        {
            //se é o player a morrer ativa a main camera
            if (this.transform.tag.Equals("Player"))
            {
                mira.enabled = false;
                _cam.GetComponent<Camera>().enabled = true;
            }
            if (this.tag.Equals("NPC"))
                _gameManager.adicionaEsqueleto();
            Destroy(this.gameObject);
        }
    }
}

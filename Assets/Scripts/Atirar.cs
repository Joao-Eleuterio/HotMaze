using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class Atirar : MonoBehaviour
{
    public Animator _animatorArma;
    public Animator _animatorMaos;
    public GameObject _mao;
    public GameObject _arma;
    [Range(0, 500)]
    public int numeroDeBalas;
    public float fireRateSoco;
    public float fireRateTiro;
    public float currentRatetoFireSoco;
    public float currentRatetoFireTiro;
    bool Dir_Esq = false;
    // Start is called before the first frame update
    void Start() 
    {
        if(SceneManager.GetActiveScene().buildIndex > 3)
            numeroDeBalas = PlayerPrefs.GetInt("Balas");
        if (SceneManager.GetActiveScene().name.Equals("Nivel1"))
            numeroDeBalas = 20;
        currentRatetoFireSoco = fireRateSoco;
        currentRatetoFireTiro = fireRateTiro;
    }
    void Update()
    {
        currentRatetoFireSoco += Time.deltaTime;
        currentRatetoFireTiro += Time.deltaTime;
        if (currentRatetoFireSoco < fireRateSoco || currentRatetoFireTiro<fireRateTiro) return;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_arma.activeInHierarchy.Equals(true) && _animatorArma!=null && currentRatetoFireTiro>= fireRateTiro)
            {     
                Shoot();
                currentRatetoFireTiro = 0;
            }
            if(_mao.activeInHierarchy==true && currentRatetoFireSoco>= fireRateSoco)
            {        
                Soco();
                currentRatetoFireSoco = 0;
            }        
        }
    }
    void Shoot()
    {
        Debug.Log("Shoot");
        if (numeroDeBalas == 0)
            return;
        _animatorArma.SetTrigger("disparar");
    }
    void Soco()
    {
        Debug.Log("Soco");
        Dir_Esq = !Dir_Esq;
        if (Dir_Esq)
            _animatorMaos.SetInteger("soco", 1);
        else
            _animatorMaos.SetInteger("soco", 2);
        _animatorMaos.SetTrigger("socoT");
    }
    public int QntBalas()
    { return numeroDeBalas; ;}
    public void RetirarBalas()
    { numeroDeBalas--;}
    public void AdicionaBalas(int valor)
    {
        numeroDeBalas += valor;
    }
}

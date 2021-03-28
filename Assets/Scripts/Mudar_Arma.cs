using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Este script muda da mao para a arma ou vice versa
/// </summary>
public class Mudar_Arma : MonoBehaviour
{
    [SerializeField]
    GameObject _arma, _mao;
    [SerializeField]
    int TemArma = 0;
    bool estaActivo;
    Atirar _atirar;
    void Start()
    {
        _atirar = GetComponent<Atirar>();
        
        _mao = GetComponentInChildren<TiraVidaComSoco>().gameObject;
        _arma = GetComponentInChildren<TiraVidaComTiro>(true).gameObject;
        UIbalas();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            TemArma = PlayerPrefs.GetInt("arma", 0);
            if (TemArma==1 && _atirar.currentRatetoFireSoco>=_atirar.fireRateSoco)
            {
                _mao.SetActive(false);
                _arma.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _atirar.currentRatetoFireTiro>=_atirar.fireRateTiro)
        {    
            _arma.SetActive(false);
            _mao.SetActive(true);
        }
    }
    public bool UIbalas()
    {
        if(_arma==null)
            _arma = GetComponentInChildren<TiraVidaComTiro>(true).gameObject;
        return (_arma.activeSelf && TemArma==1);
    }
}

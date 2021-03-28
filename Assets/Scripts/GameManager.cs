using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text lblvida;
    [SerializeField]
    int TotalEsqueletos;
    [SerializeField]
    int NrEsqueletosNivel;
    [SerializeField]
    int EsqueletosMortos;
    [SerializeField]
    GameObject MenuDerrota;
    [SerializeField]
    Text DadosJogo;
    public GameObject player;
    Vida _vida;
    [SerializeField]
    Text mira;
    [SerializeField]
    Text Balas;
    [SerializeField]
    Text Chaves;
    [SerializeField]
    Text Granadas;
    public Atirar _atirar;
    Apanhar_arma _arm;
    public AbreBau _bau1;
    public AbreBau _bau2;
    public AbreBau _bau3;
    bool armaApanhada = false;
    int TemArma;
    Mudar_Arma mudaArma;
    Atirar_granada _atirar_granada;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
            _bau3 = GameObject.FindGameObjectWithTag("Bau3").GetComponent<AbreBau>();
        _bau1 = GameObject.FindGameObjectWithTag("Bau1").GetComponent<AbreBau>();
        _bau2 = GameObject.FindGameObjectWithTag("Bau2").GetComponent<AbreBau>();
        _arm = GameObject.FindObjectOfType<Apanhar_arma>();
        _atirar = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar>();
        _vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        mudaArma = GameObject.FindGameObjectWithTag("Player").GetComponent<Mudar_Arma>();
       // player = GameObject.FindGameObjectWithTag("Player");
        _atirar_granada = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar_granada>();
        //garantir que so existe um GameManager
        GameManager[] ops = GameManager.FindObjectsOfType<GameManager>();
        if (ops.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    public void recomecarNivel()
    {
        EsqueletosMortos = 0;
        Debug.Log("Recomecou!");
    }
    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //sempre que uma cena é carregada 
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex < 4 || SceneManager.GetActiveScene().name.Equals("MenuFinal")) return;
        EsqueletosMortos = 0;
        //se estiver no nível 1 fica sem arma
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            PlayerPrefs.SetInt("arma", 0);
            PlayerPrefs.Save();
        }
        Debug.Log("Cena carregada");
        //contar Esqueletos
        NrEsqueletosNivel = GameObject.FindGameObjectsWithTag("NPC").Length;
        if (DadosJogo == null)
            DadosJogo = GameObject.FindGameObjectWithTag("TxtEsqueletos").GetComponent<Text>();
        if (MenuDerrota == null)
            MenuDerrota = GameObject.FindObjectOfType<Canvas>().transform.Find("MenuDerrota").gameObject;
        if (lblvida == null)
            lblvida = GameObject.FindGameObjectWithTag("TxtVida").GetComponent<Text>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (mira == null)
            mira = GameObject.FindGameObjectWithTag("mira").GetComponent<Text>();
        if (Balas == null)
            Balas = GameObject.FindGameObjectWithTag("TxtBalas").GetComponent<Text>();
        if (Chaves == null)
            Chaves = GameObject.FindGameObjectWithTag("TxtChaves").GetComponent<Text>();
        if (Granadas == null)
            Granadas = GameObject.FindGameObjectWithTag("TxtGranadas").GetComponent<Text>();
        if (_bau1 == null)
            _bau1 = GameObject.FindGameObjectWithTag("Bau1").GetComponent<AbreBau>();
        if (_bau2 == null)
            _bau2 = GameObject.FindGameObjectWithTag("Bau2").GetComponent<AbreBau>();
        if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
            if (_bau3 == null)
                _bau3 = GameObject.FindGameObjectWithTag("Bau3").GetComponent<AbreBau>();
        AtualizarDadosJogador();
    }
    public void adicionaEsqueleto()
    {
        TotalEsqueletos++;
        EsqueletosMortos++;
        AtualizarDadosJogador();
    }
    void AtualizarDadosJogador()
    {
        if (_vida != null)
        {
            lblvida.text = "Vida: " + _vida.GetVida();
            if (_vida.GetVida() <= 20)
                lblvida.color = Color.red;
            else
                lblvida.color = Color.green;
            if (_vida.GetVida() > 100)
                lblvida.color = Color.cyan;
        }
        if (DadosJogo != null)
            DadosJogo.text = "Esqueletos: " + NrEsqueletosNivel + "|" + EsqueletosMortos;
        if (MenuDerrota != null)
            MenuDerrota.SetActive(false);
        if (Balas != null)
        {
            if (mudaArma == null)
                mudaArma = GameObject.FindGameObjectWithTag("Player").GetComponent<Mudar_Arma>();
            if (mudaArma.UIbalas())
            {
                Balas.enabled = true;
                if (player != null)
                    if (_atirar == null)
                        _atirar = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar>();
                Balas.text = "Balas: " + _atirar.QntBalas();
            }
            else
                Balas.enabled = false;
        }
        else
            Balas = GameObject.FindGameObjectWithTag("TxtBalas").GetComponent<Text>();
        if (Chaves != null)
        {
            if (_bau1.GetChave().Equals(1))
                Chaves.text = "Chave da jaula 1";
            if (_bau2.GetChave().Equals(1))
                Chaves.text = "Chave da jaula 2";
            if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
            {
                if (_bau3.GetChave().Equals(1))
                    Chaves.text = "Chave da jaula 3";
                if (_bau1.GetChave().Equals(0) && _bau2.GetChave().Equals(0) && _bau3.GetChave().Equals(0))
                    Chaves.text = "Não tem chaves";
                if (_bau1.GetChave().Equals(1) && _bau2.GetChave().Equals(1) && _bau3.GetChave().Equals(0))
                    Chaves.text = "Tem a chave da jaula 1 e 2";
                if (_bau1.GetChave().Equals(0) && _bau2.GetChave().Equals(1) && _bau3.GetChave().Equals(1))
                    Chaves.text = "Tem a chave da jaula 2 e 3";
                if (_bau1.GetChave().Equals(1) && _bau2.GetChave().Equals(0) && _bau3.GetChave().Equals(1))
                    Chaves.text = "Tem a chave da jaula 1 e 3";
                if (_bau1.GetChave().Equals(1) && _bau2.GetChave().Equals(1) && _bau3.GetChave().Equals(1))
                    Chaves.text = "Tem todas as chaves";
            }
            else
            {
                if (_bau1.GetChave().Equals(0) && _bau2.GetChave().Equals(0))
                    Chaves.text = "Não tem chaves";
                if (_bau1.GetChave().Equals(1) && _bau2.GetChave().Equals(1))
                    Chaves.text = "Tem todas as chaves";
            }
            if (Granadas != null)
                Granadas.text = "Granadas: " + _atirar_granada.GetGranada();
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex < 4 || SceneManager.GetActiveScene().name.Equals("MenuFinal")) return;

        if (player == null)
        {
            //isto faz aparecer o cursor do rato e desbloqueia
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            MenuDerrota.SetActive(true);
            Time.timeScale = 0;
            lblvida.enabled = false;
            Chaves.enabled = false;
            DadosJogo.enabled = false;
            Granadas.enabled = false;
            return;
        }
        else
            _vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        AtualizarDadosJogador();
        if (_atirar == null)
            _atirar = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar>();
        if (_atirar_granada == null)
            _atirar_granada = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar_granada>();
        if (NrEsqueletosNivel==EsqueletosMortos)
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                TemArma = PlayerPrefs.GetInt("arma", 0);
                if (TemArma == 1)
                    if (SceneManager.GetActiveScene().buildIndex > 2)
                    {
                        PlayerPrefs.SetInt("Balas", _atirar.QntBalas());
                        PlayerPrefs.Save();
                    }
                PlayerPrefs.SetInt("Granadas", _atirar_granada.GetGranada());
                PlayerPrefs.SetInt("Vida", _vida.GetVida());
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                PlayerPrefs.DeleteAll();
                TemArma = 0;
                SceneManager.LoadScene("MenuPrincipal");
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("Nivel1"))
        {
            if (_arm.Apanhou())
                armaApanhada = true;
            else
                Balas.enabled = false;
        }
    }
}

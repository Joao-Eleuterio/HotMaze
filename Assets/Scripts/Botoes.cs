using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Botoes : MonoBehaviour
{
    [SerializeField]
    Text messagem;
    [SerializeField]
    GameObject MenuPausa;
    [SerializeField]
    Text mira;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex < 4 || SceneManager.GetActiveScene().name.Equals("MenuFinal"))
                return; 
            mira.enabled = false;
            MenuPausa.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;    
        }
        if (SceneManager.GetActiveScene().buildIndex < 4 || SceneManager.GetActiveScene().name.Equals("MenuFinal"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void MenuPausa_Continuar()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MenuPausa.SetActive(false);
        mira.enabled = true;
        Time.timeScale = 1;
        Debug.Log("Continuar");
    }
    public void Menus_Sair()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void RecomecarNivel()
    {
        Time.timeScale = 1;
        FindObjectOfType<GameManager>().recomecarNivel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuPrincipal_IniciarJogo()
    {  SceneManager.LoadScene("Nivel1");}

    public void MenuPrincipal_Objetivo()
    { SceneManager.LoadScene("MenuObjetivo"); }
    public void MenuPrincipal_Creditos()
    { SceneManager.LoadScene("MenuCreditos"); }
    public void MenuPrincipal_ComoJogar()
    { SceneManager.LoadScene("MenuComoJogar");}
  
    public void MenuPrincipal_Sair()
    { Application.Quit(); }

}

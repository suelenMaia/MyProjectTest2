using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassagemNivel : MonoBehaviour {
    public GameObject[] avatares;
    public Text txtNumNivel, lblFeedback;
    int nivel, scoreAcerto;
	// Use this for initialization
	void Start () {
        //nivel = 3;
        nivel = PlayerPrefs.GetInt("Nivel");
        scoreAcerto = PlayerPrefs.GetInt("ScoreAcerto");
        avatares[0].SetActive(false);
        avatares[1].SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine("SalvaDadosServidor");
        StartCoroutine("FormataCena");
	}

    public void SalvaDadosServidor()
    {
        scoreAcerto = 0;
        PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
        PlayerPrefs.SetInt("Nivel", nivel);
    }
    IEnumerator FormataCena()
    {
        if (nivel == 2)
        {
            txtNumNivel.text = nivel.ToString();
            lblFeedback.text = "Parabéns Marujo!\nVocê passou para o nível";
            avatares[0].SetActive(true);
            SalvaDadosServidor();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Questao");
        }
        else if (nivel > 2)
        {
            lblFeedback.text = "Parabéns Marujo!\nVocê completou a missão";
            avatares[1].SetActive(true);
            SalvaDadosServidor();
            //nivel = 0;
            //PlayerPrefs.SetInt("Nivel", nivel);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Resposta");
        }
    }
}

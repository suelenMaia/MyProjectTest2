using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassagemNivel : MonoBehaviour {
    public Text txtNumNivel;
    private int nivel, scoreAcerto;
	// Use this for initialization
	void Start () {
        //nivel = 2;
        nivel = PlayerPrefs.GetInt("Nivel");
        scoreAcerto = PlayerPrefs.GetInt("ScoreAcerto");
        txtNumNivel.text = nivel.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("SalvaDadosServidor");
	}

    IEnumerator SalvaDadosServidor()
    {
        yield return new WaitForSeconds(3);
        scoreAcerto = 0;
        PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
        PlayerPrefs.SetInt("Nivel", nivel);
        SceneManager.LoadScene("Questao");
    }
}

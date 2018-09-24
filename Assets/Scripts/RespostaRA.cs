using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespostaRA : MonoBehaviour {
    public GameObject[] respostas;
    Ray ray;
    int scoreErro = 0, scoreAcerto = 0, numQuestao = 0, nivel;
    //string imgName;
    // Use this for initialization
    void Start () {
        respostas[0].SetActive(false);
        respostas[1].SetActive(false);
        scoreErro = PlayerPrefs.GetInt("ScoreErro");
        scoreAcerto = PlayerPrefs.GetInt("ScoreAcerto");
        numQuestao = PlayerPrefs.GetInt("NumQuestao");
        nivel = PlayerPrefs.GetInt("Nivel");
        if (nivel > 2)
        {
           respostas[1].SetActive(true);
            nivel = 0;
            PlayerPrefs.SetInt("Nivel", nivel);
        }
        else
        {
            respostas[0].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string nomeImg = hit.transform.name;
                Debug.Log(nomeImg);
                VerificaResposta(nomeImg);

                
            }
        }
    }

    public void VerificaResposta(string nomeImg)
    {
        if (nomeImg == "Cylinder")
        {
            scoreAcerto++;

            if (scoreErro > 0)
            {
                scoreErro--;
                PlayerPrefs.SetInt("ScoreErro", scoreErro);
            }

            if (numQuestao == 3)
            {
                numQuestao = 0;
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
                SceneManager.LoadScene("Resultado");
            }
            else if (numQuestao < 2)
            {
                numQuestao++;
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
                SceneManager.LoadScene("Resultado");

            }
            else
            {
                nivel++;
                numQuestao = 0;
                scoreErro = 0;
                PlayerPrefs.SetInt("ScoreErro", scoreErro);
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetInt("Nivel", nivel);
                PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
                SceneManager.LoadScene("PassagemNivel");
            }
        }
        else
        {
            scoreErro++;
            //persiste o score durante o jogo, é usado na próxima cena para exibir o barco com os danos
            //Fonte:https://stackoverflow.com/questions/22862932/keeping-scores-in-unity-and-pass-to-next-scene
            PlayerPrefs.SetInt("ScoreErro", scoreErro);
            SceneManager.LoadScene("Resultado");

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespostaRA : MonoBehaviour {
    
    Ray ray;
    int scoreErro = 0, scoreAcerto = 0, numQuestao = 0;
    string imgName;
    // Use this for initialization
    void Start () {
        scoreErro = PlayerPrefs.GetInt("ScoreErro");
        scoreAcerto = PlayerPrefs.GetInt("ScoreAcerto");
        numQuestao = PlayerPrefs.GetInt("NumQuestao");
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                imgName = hit.transform.name;
                Debug.Log(imgName);

                if(imgName == "Cylinder")
                {
                    scoreAcerto++;

                    if (numQuestao == 3)
                    {
                        numQuestao = 0;
                        PlayerPrefs.SetInt("NumQuestao", numQuestao);
                    }
                    else
                    {
                        numQuestao++;
                        PlayerPrefs.SetInt("NumQuestao", numQuestao);
                    }

                    if (scoreErro > 0)
                    {
                        scoreErro--;
                        PlayerPrefs.SetInt("ScoreErro", scoreErro);
                    }
                    PlayerPrefs.SetInt("ScoreAcerto", scoreAcerto);
                    SceneManager.LoadScene("Resultado");
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
    }
}

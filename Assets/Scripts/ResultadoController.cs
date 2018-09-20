using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultadoController : MonoBehaviour {

    public GameObject [] panel;
    int score;

    void Start()
    {
        panel[0].SetActive(false);
        panel[1].SetActive(false);
        panel[2].SetActive(false);
        panel[3].SetActive(false);
        panel[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("ScoreErro");
        StartCoroutine("HideUnhide");
    }

    IEnumerator HideUnhide()
    {
        switch (score)
        {
            case 0:
                panel[0].SetActive(true);
                yield return new WaitForSeconds(3);
                PlayerPrefs.SetInt("ScoreErro", score);
                SceneManager.LoadScene("Questao");
                break;

            case 1:
                panel[1].SetActive(true);
                yield return new WaitForSeconds(3);
                PlayerPrefs.SetInt("ScoreErro", score);
                SceneManager.LoadScene("Questao");
                break;
            case 2:
                panel[2].SetActive(true);
                yield return new WaitForSeconds(3);
                PlayerPrefs.SetInt("ScoreErro", score);
                SceneManager.LoadScene("Questao");
                break;
            case 3:
                panel[3].SetActive(true);
                yield return new WaitForSeconds(3);
                PlayerPrefs.SetInt("ScoreErro", score);
                PlayerPrefs.SetInt("NumQuestao", 3);
                SceneManager.LoadScene("Questao");
                break;
               
            default:
                panel[4].SetActive(true);
                yield return new WaitForSeconds(3);
                PlayerPrefs.DeleteKey("ScoreErro");
                PlayerPrefs.DeleteKey("ScoreAcerto");
                PlayerPrefs.DeleteKey("NumQuestao");
                PlayerPrefs.DeleteKey("Nivel");
                SceneManager.LoadScene("Questao");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultadoController : MonoBehaviour {

    public GameObject [] panel;
    int score;

    void Start()
    {
        panel[1].SetActive(false);
        panel[2].SetActive(false);
        panel[3].SetActive(false);
        panel[4].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("Score");
        StartCoroutine("hideUnhide");
        Debug.Log("Score cena barco update " + score);
    }

    IEnumerator hideUnhide()
    {
       yield return (new WaitForSeconds(2));
        switch (score)
        {
            case 0:
                panel[0].SetActive(true);
                panel[1].SetActive(false);
                panel[2].SetActive(false);
                panel[3].SetActive(false);
                panel[4].SetActive(false);
                new WaitForSeconds(3);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("Questao1");
                break;

            case 1:
                panel[0].SetActive(false);
                panel[1].SetActive(true);
                panel[2].SetActive(false);
                panel[3].SetActive(false);
                panel[4].SetActive(false);
                new WaitForSeconds(3);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("Resposta1");
                break;
            case 2:
                panel[0].SetActive(false);
                panel[1].SetActive(false);
                panel[2].SetActive(true);
                panel[3].SetActive(false);
                panel[4].SetActive(false);
                new WaitForSeconds(3);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("Resposta1");
                break;
            case 3:
                panel[0].SetActive(false);
                panel[1].SetActive(false);
                panel[2].SetActive(false);
                panel[3].SetActive(true);
                panel[4].SetActive(false);
                new WaitForSeconds(3);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("Resposta1");
                break;
               
            default:
                panel[0].SetActive(false);
                panel[1].SetActive(false);
                panel[2].SetActive(false);
                panel[3].SetActive(false);
                panel[4].SetActive(true);
                PlayerPrefs.SetInt("Score", 0);
                SceneManager.LoadScene("Questao1");
                break;
        }

    }


}

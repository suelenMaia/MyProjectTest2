using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerQuestion : MonoBehaviour
{
    public GameObject[] panel;
    public Text [] txtQuestao;
    string respCerta1, respCerta2, respCertaSeg;
    string JsonDataString;
    int numQuestao = 0;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine("HideUnhide");
        panel[0].SetActive(false);
        panel[1].SetActive(false);
        panel[2].SetActive(false);
        
        StartCoroutine(GetQuestion());
    }

    // Update is called once per frame
    void Update()
    {
        numQuestao = PlayerPrefs.GetInt("NumQuestao");
        //StartCoroutine("HideUnhide");
    }

    private IEnumerator GetQuestion()
    {
        string url = "http://192.168.2.103/api.php?action=returnQuestion";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                txtQuestao[0].text = "Sem conexão com o servidor";
                txtQuestao[1].text = "Sem conexão com o servidor";
                txtQuestao[2].text = "Sem conexão com o servidor";
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Question[] entities = JsonHelper.getJsonArray<Question>(jsonResult);
                    txtQuestao[0].text = entities[0].descricao;
                    txtQuestao[1].text = entities[1].descricao;
                    txtQuestao[2].text = entities[2].descricao;
                    respCerta1 = entities[0].imagem;
                    respCerta2 = entities[1].imagem;
                    respCertaSeg = entities[2].imagem;
                }
            }  
        }
    }
    void HideUnhide()
    {
        switch (numQuestao)
        {
            case 0:
                panel[0].SetActive(true);
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetString("RespCerta", respCerta1);
            
                break;

            case 1:
                panel[1].SetActive(true);
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetString("RespCerta", respCerta2);
               
                break;
            case 2:
                panel[2].SetActive(true);
                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                PlayerPrefs.SetString("RespCerta", respCertaSeg);
                
                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerQuestion : MonoBehaviour
{
    //public GameObject[] panel;
    public Text txtQuestao, lblTitulo;
    string JsonDataString;
    string[] questoes, respostas;
    int numQuestao, nivel = 1, scoreErro;
    // Use this for initialization
    void Start ()
    {
       
        numQuestao = PlayerPrefs.GetInt("NumQuestao");
        scoreErro = PlayerPrefs.GetInt("ScoreErro");
        if (numQuestao == 0)
        {
            PlayerPrefs.SetInt("NumQuestao", numQuestao+1);
            StartCoroutine(GetQuestion());
        }
        else
        {
            StartCoroutine(GetQuestion());
        }
        
        
        //panel[0].SetActive(false);
        //panel[1].SetActive(false);
        //panel[2].SetActive(false);

        
        
        //nivel = PlayerPrefs.GetInt("Nivel");
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private IEnumerator GetQuestion()
    {
        
        string url = "http://192.168.137.1/api.php?action=returnQuestion";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                txtQuestao.text = "Sem conexão com o servidor";
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Question[] entities = JsonHelper.getJsonArray<Question>(jsonResult);
                    Debug.Log(entities.Length);
                    questoes = new string[3];
                    for (int i = 0; i <= entities.Length -1; i++)
                    {
                        string numNivel = nivel.ToString();
                        if (entities[i].numNivel == numNivel) 
                        {
                            questoes[i] = entities[i].descricao;
                            //respostas[i] = entities[i].imagem;
                        }
                    }
                    if(numQuestao == 1)
                    {
                        txtQuestao.text = questoes[0];
                        lblTitulo.text = "Questão 1";
                        PlayerPrefs.SetInt("NumQuestao", numQuestao);
                        //PlayerPrefs.SetString("RespCerta", respostas[0]);
                    }
                    else
                    {
                        if (numQuestao == 2)
                        {
                            txtQuestao.text = questoes[1];
                            lblTitulo.text = "Questão 2";
                            PlayerPrefs.SetInt("NumQuestao", numQuestao);
                            //PlayerPrefs.SetString("RespCerta", respostas[1]);
                        }
                        else
                        {
                            if(numQuestao == 3 && scoreErro == 3)
                            {
                                txtQuestao.text = questoes[2];
                                lblTitulo.text = "Questão Motivadora";
                                PlayerPrefs.SetInt("NumQuestao", numQuestao);
                                //PlayerPrefs.SetString("RespCerta", respostas[2]);
                            }
                            
                        }
                    }
                }
            }  
        }
    }
   
}

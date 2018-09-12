using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControllerQuestion : MonoBehaviour
{

    public Text txtQuestion;
    string JsonDataString;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(GetQuestion());
	}

    private IEnumerator GetQuestion()
    {
        string url = "http://172.16.39.73/api.php?action=returnQuestion";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                txtQuestion.text = "Sem conexão com o servidor";
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Question[] entities = JsonHelper.getJsonArray<Question>(jsonResult);
                    Debug.Log(entities[0].descricao);
                    txtQuestion.text = entities[0].descricao;
                }
            }
            
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
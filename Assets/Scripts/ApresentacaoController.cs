using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApresentacaoController : MonoBehaviour {

    public InputField inputNome, inputSenha;
    public Dropdown turma;
    string txtnome, txtsenha, txtturma;
    // Use this for initialization
    private void Start()
    {
        
    }

    public void GetSetText()
    {

        txtnome = inputNome.text;
        txtsenha = inputSenha.text;
        txtturma = turma.captionText.text;
        
        Debug.Log("Turma: "+txtturma);
        StartCoroutine(InserirAluno(txtnome, txtsenha, txtturma));
        StartCoroutine(GetAluno(txtnome));
        SceneManager.LoadScene("Questao");

    }

    private IEnumerator InserirAluno(string nome, string senha, string turma)
    {
        string url = "http://localhost/apiInsert.php";
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        string actionStr = "gambs=gamb&action=insertNewStudent&nome=" + nome + "&senha=" + senha + "&turma=" + turma + "&gambs1=gamb1";
        MultipartFormDataSection dataSection = new MultipartFormDataSection(actionStr);
        //Debug.Log("SECTION TYPE: " + dataSection.contentType);
        form.Add(dataSection);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return www.SendWebRequest();
            Debug.Log("antes do if de erro");
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("no if de erro");
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Dados salvos no servidor");
                
            }

        }
    }
    private IEnumerator GetAluno(string nomeAluno)
    {
        string url = "http://localhost/api.php?action=getAluno&nomeAluno="+nomeAluno;
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                //txtQuestao.text = "Sem conexão com o servidor";
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("no if isDone do getAluno");
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult);
                    Aluno[] entities = JsonHelper.getJsonArray<Aluno>(jsonResult);

                    Debug.Log("Tamanho resp " + entities.Length);
                }
            }
        }
    }
}

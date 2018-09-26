using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
    }

    public IEnumerator InserirAluno(string nome, string senha, string turma)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        string actionStr = "gambs=gamb&action=insertNewStudent&nome=" + nome + "&senha=" + senha + "&turma=" + turma + "&gambs1=gamb1";
        MultipartFormDataSection dataSection = new MultipartFormDataSection(actionStr);
        //Debug.Log("SECTION TYPE: " + dataSection.contentType);
        form.Add(dataSection);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/apiInsert.php", form);
        www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form uploaded "+ www.downloadHandler.text);
            Debug.Log("Status code " + www.responseCode);
            
        }

        //WWWForm form = new WWWForm();
        //form.AddField("action", "insertNewStudent");
        //form.AddField("nome", nome);
        //form.AddField("senha", senha);
        //form.AddField("turma", turma);
        //Debug.Log("***88"+form.data.ToString());
        
        //UnityWebRequest www = UnityWebRequest.Post("http://localhost/apiInsert.php", form);
        
        //yield return www.SendWebRequest();

        //if (www.error != null)
        //{
        //    Debug.Log("Erro: " + www.error);
        //}
        //else
        //{
        //    Debug.Log("All OK");
        //    Debug.Log("Text: " + www.downloadHandler.text);
        //}
    }
}

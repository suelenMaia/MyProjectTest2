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
        WWWForm form = new WWWForm();
        form.AddField("action", "insertNewStudent");
        form.AddField("nome", nome);
        form.AddField("senha", senha);
        form.AddField("turma", turma);
        
        
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/apiInsert.php", form);
        
        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.Log("Erro: " + www.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Text: " + www.downloadHandler.text);
        }
    }
}

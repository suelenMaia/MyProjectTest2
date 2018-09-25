using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApresentacaoController : MonoBehaviour {

    public InputField senha;
    public Text txtsenha;
    // Use this for initialization
    private void Start()
    {
        senha.ActivateInputField();
    }

    public void GetSetText()
    {
        txtsenha.text = senha.text;
        Debug.Log(txtsenha);
    }
}

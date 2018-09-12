using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespostaRA : MonoBehaviour {
    RaycastHit hit;
    Ray ray;
    int qtdErro = 1;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(" you clicked on ");

            if (hit.collider.gameObject.name == "Cube")
            {
                qtdErro++;
                SceneManager.LoadScene("Resultado");                
            }
            //else
            //{
            //    if(hit.collider.gameObject.name == "Sphere")
            //    {
            //        qtdErro = 0;
            //        SceneManager.LoadScene("Resultado");
            //    }
            //}
        }

    }
    
    public int getScore()
    {
        return qtdErro;
    }
 

}

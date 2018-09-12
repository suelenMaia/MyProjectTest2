using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespostaRA : MonoBehaviour {
    RaycastHit hit;
    Ray ray;
    int score = 0;
    
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
                score++;
                //persiste o score durante o jogo, é usado na próxima cena para exibir o barco com os danos
                //Fonte:https://stackoverflow.com/questions/22862932/keeping-scores-in-unity-and-pass-to-next-scene
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("Resultado");    
                
            }
            else
            {
                if(hit.collider.gameObject.name == "Sphere")
                {
                    score = 0;
                    SceneManager.LoadScene("Resultado");
                }
            }
        }

    }

}

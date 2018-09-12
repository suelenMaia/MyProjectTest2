using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class imageTouth : MonoBehaviour {
    RaycastHit hit;
    Ray ray;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(" you clicked on " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "Cube")
            {
                SceneManager.LoadScene("testeResp");
            }
        }

    }
}

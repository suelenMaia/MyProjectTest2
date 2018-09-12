using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {
    public GameObject panel;
    bool status = true;

	public void showHidePanel()
    {
        
        if (status == true)
        {
            panel.gameObject.SetActive(false);
            status = false;
        }
        else
        {
            panel.gameObject.SetActive(true);
            status = true;
        }
    }
}

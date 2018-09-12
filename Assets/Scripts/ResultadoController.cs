using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultadoController : MonoBehaviour {

    public GameObject [] panel;
    RespostaRA resp;

    void Start()
    {
        //StartCoroutine("HideUnhide");
        panel[1].SetActive(false);
        panel[2].SetActive(false);
        panel[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("HideUnhide");
        new WaitForSeconds(2);
        switch (resp.getScore())
        {
            case 1:
                panel[0].SetActive(false);
                panel[1].SetActive(true);
                break;
            case 2:
                panel[1].SetActive(false);
                panel[2].SetActive(true);
                break;
            case 3:
                panel[2].SetActive(false);
                panel[3].SetActive(true);
                break;
            default:
                panel[0].SetActive(true);
                panel[1].SetActive(false);
                panel[2].SetActive(false);
                panel[3].SetActive(false);
                break;
        }

    }

    //IEnumerator hideUnhide()
    //{
    //    yield return (new WaitForSeconds(2));
    //    switch (resp.getScore())
    //    {
    //        case 1:
    //            panel[0].SetActive(false);
    //            panel[1].SetActive(true);
    //            break;
    //        case 2:
    //            panel[1].SetActive(false);
    //            panel[2].SetActive(true);
    //            break;
    //        case 3:
    //            panel[2].SetActive(false);
    //            panel[3].SetActive(true);
    //            break;
    //        default:
    //            panel[0].SetActive(true);
    //            panel[1].SetActive(false);
    //            panel[2].SetActive(false);
    //            panel[3].SetActive(false);
    //            break;
    //    }

    //}


}

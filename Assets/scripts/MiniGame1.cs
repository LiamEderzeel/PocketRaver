using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour {

    private bool _pil = true;
    private bool _half1 = true;
    private bool _half2 = true;
    private bool _kwarter1 = true;
    private bool _kwarter2 = true;
    private bool _kwarter3 = true;
    private bool _kwarter4 = true;

    private GameObject Pil;
    private GameObject PilHalf1;
    private GameObject PilHalf2;
    private GameObject PilKwarter1;
    private GameObject PilKwarter2;
    private GameObject PilKwarter3;
    private GameObject PilKwarter4;

    void Awake ()
    {
        Pil = GameObject.Find("Pil");
        PilHalf1 = GameObject.Find("PilHalf1");
        PilHalf2 = GameObject.Find("PilHalf2");
        PilKwarter1 = GameObject.Find("PilKwarter1");
        PilKwarter2 = GameObject.Find("PilKwarter2");
        PilKwarter3 = GameObject.Find("PilKwarter3");
        PilKwarter4 = GameObject.Find("PilKwarter4");

    }
    void Start ()
    {
        Vector3 holdingPos = new Vector3(0,0,-200);
        PilHalf1.GetComponent<Transform>().position = holdingPos;
        PilHalf2.GetComponent<Transform>().position = holdingPos;
        PilKwarter1.GetComponent<Transform>().position = holdingPos;
        PilKwarter2.GetComponent<Transform>().position = holdingPos;
        PilKwarter3.GetComponent<Transform>().position = holdingPos;
        PilKwarter4.GetComponent<Transform>().position = holdingPos;
    }

    void Update ()
    {
        Vector3 stagingPos = new Vector3(0,0,0);
        Vector3 holdingPos = new Vector3(0,0,-200);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast (ray, out _hit))
            {

                if(_hit.transform.name == "Pil")
                {
                    PilHalf1.GetComponent<Transform>().position = Pil.GetComponent<Transform>().position;
                    PilHalf2.GetComponent<Transform>().position = Pil.GetComponent<Transform>().position;
                    Pil.GetComponent<Transform>().position = holdingPos;
                }
                else if(_hit.transform.name == "PilHalf1" || _hit.transform.name == "PilHalf2")
                {
                    print(1);
                    if(_hit.transform.name == "PilHalf1")
                    {
                        print(2);
                        PilKwarter1.GetComponent<Transform>().position = PilHalf1.GetComponent<Transform>().position;
                        PilKwarter2.GetComponent<Transform>().position = PilHalf1.GetComponent<Transform>().position;
                        PilHalf1.GetComponent<Transform>().position = holdingPos;
                    }
                    if(_hit.transform.name == "PilHalf2")
                    {
                        PilKwarter3.GetComponent<Transform>().position = PilHalf2.GetComponent<Transform>().position;
                        PilKwarter4.GetComponent<Transform>().position = PilHalf2.GetComponent<Transform>().position;
                        PilHalf2.GetComponent<Transform>().position = holdingPos;
                    }
                }
            }
        }
    }
}

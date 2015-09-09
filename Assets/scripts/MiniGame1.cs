using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour {

    private GameObject Pil;
    private GameObject PilHalf1;
    private GameObject PilHalf2;
    private GameObject PilKwarter1;
    private GameObject PilKwarter2;
    private GameObject PilKwarter3;
    private GameObject PilKwarter4;
    private int PilKwartersDestroyed;
    private bool _playing = true;

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

        if(PilKwartersDestroyed >= 3)
        {
            print("win");
            _playing = false;
        }

        if (Input.GetMouseButtonDown(0) && _playing)
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast (ray, out _hit))
            {
                if(_hit.transform.name == "Pil")
                {
                    PilHalf1.GetComponent<Transform>().position = Pil.GetComponent<Transform>().position;
                    PilHalf1.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,1f),0);
                    PilHalf1.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    PilHalf2.GetComponent<Transform>().position = Pil.GetComponent<Transform>().position;
                    PilHalf2.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,1f),0);
                    PilHalf2.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    Pil.GetComponent<Transform>().position = holdingPos;
                }
                else if(_hit.transform.name == "PilHalf1" || _hit.transform.name == "PilHalf2")
                {
                    if(_hit.transform.name == "PilHalf1")
                    {
                        PilKwarter1.GetComponent<Transform>().position = PilHalf1.GetComponent<Transform>().position;
                        PilKwarter1.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f,0f), Random.Range(0f,1f),0);
                        PilKwarter2.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilKwarter2.GetComponent<Transform>().position = PilHalf1.GetComponent<Transform>().position;
                        PilKwarter2.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,0f),0);
                        PilKwarter2.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilHalf1.GetComponent<Transform>().position = holdingPos;
                    }

                    if(_hit.transform.name == "PilHalf2")
                    {
                        PilKwarter3.GetComponent<Transform>().position = PilHalf2.GetComponent<Transform>().position;
                        PilKwarter3.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f,1f), Random.Range(0f,1f),0);
                        PilKwarter3.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilKwarter4.GetComponent<Transform>().position = PilHalf2.GetComponent<Transform>().position;
                        PilKwarter4.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,0f),0);
                        PilKwarter4.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilHalf2.GetComponent<Transform>().position = holdingPos;
                    }
                }
                else if(_hit.transform.name == "PilKwarter1" || _hit.transform.name == "PilKwarter2" || _hit.transform.name == "PilKwarter3" || _hit.transform.name == "PilKwarter4")
                {
                    if(_hit.transform.name == "PilKwarter1")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter1.GetComponent<Transform>().position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter2")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter2.GetComponent<Transform>().position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter3")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter3.GetComponent<Transform>().position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter4")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter4.GetComponent<Transform>().position = holdingPos;
                    }
                }
            }
        }
    }
}

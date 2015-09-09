using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour {

    private Transform PilTransform;
    private Transform PilHalf1Transform;
    private Rigidbody PilHalf1Rigidbody;
    private Transform PilHalf2Transform;
    private Rigidbody PilHalf2Rigidbody;
    private Transform PilKwarter1Transform;
    private Rigidbody PilKwarter1Rigidbody;
    private Transform PilKwarter2Transform;
    private Rigidbody PilKwarter2Rigidbody;
    private Transform PilKwarter3Transform;
    private Rigidbody PilKwarter3Rigidbody;
    private Transform PilKwarter4Transform;
    private Rigidbody PilKwarter4Rigidbody;
    private int PilKwartersDestroyed;
    private bool _playing = true;

    void Awake ()
    {
        PilTransform = GameObject.Find("Pil").GetComponent<Transform>();
        PilHalf1Transform = GameObject.Find("PilHalf1").GetComponent<Transform>();
        PilHalf1Rigidbody = GameObject.Find("PilHalf1").GetComponent<Rigidbody>();
        PilHalf2Transform = GameObject.Find("PilHalf2").GetComponent<Transform>();
        PilHalf2Rigidbody = GameObject.Find("PilHalf2").GetComponent<Rigidbody>();
        PilKwarter1Transform = GameObject.Find("PilKwarter1").GetComponent<Transform>();
        PilKwarter1Rigidbody = GameObject.Find("PilKwarter1").GetComponent<Rigidbody>();
        PilKwarter2Transform = GameObject.Find("PilKwarter2").GetComponent<Transform>();
        PilKwarter2Rigidbody = GameObject.Find("PilKwarter2").GetComponent<Rigidbody>();
        PilKwarter3Transform = GameObject.Find("PilKwarter3").GetComponent<Transform>();
        PilKwarter3Rigidbody = GameObject.Find("PilKwarter3").GetComponent<Rigidbody>();
        PilKwarter4Transform = GameObject.Find("PilKwarter4").GetComponent<Transform>();
        PilKwarter4Rigidbody = GameObject.Find("PilKwarter4").GetComponent<Rigidbody>();

    }
    void Start ()
    {
        Vector3 holdingPos = new Vector3(0,0,-200);
        PilHalf1Transform.position = holdingPos;
        PilHalf2Transform.position = holdingPos;
        PilKwarter1Transform.position = holdingPos;
        PilKwarter2Transform.position = holdingPos;
        PilKwarter3Transform.position = holdingPos;
        PilKwarter4Transform.position = holdingPos;
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
                    PilHalf1Transform.position = PilTransform.position;
                    PilHalf1Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,1f),0);
                    PilHalf1Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    PilHalf2Transform.position = PilTransform.position;
                    PilHalf2Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,1f),0);
                    PilHalf2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    PilTransform.position = holdingPos;
                }
                else if(_hit.transform.name == "PilHalf1" || _hit.transform.name == "PilHalf2")
                {
                    if(_hit.transform.name == "PilHalf1")
                    {
                        PilKwarter1Transform.position = PilHalf1Transform.position;
                        PilKwarter1Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(0f,1f),0);
                        PilKwarter2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilKwarter2Transform.position = PilHalf1Transform.position;
                        PilKwarter2Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,0f),0);
                        PilKwarter2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilHalf1Transform.position = holdingPos;
                    }

                    if(_hit.transform.name == "PilHalf2")
                    {
                        PilKwarter3Transform.position = PilHalf2Transform.position;
                        PilKwarter3Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(0f,1f),0);
                        PilKwarter3Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilKwarter4Transform.position = PilHalf2Transform.position;
                        PilKwarter4Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,0f),0);
                        PilKwarter4Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        PilHalf2Transform.position = holdingPos;
                    }
                }
                else if(_hit.transform.name == "PilKwarter1" || _hit.transform.name == "PilKwarter2" || _hit.transform.name == "PilKwarter3" || _hit.transform.name == "PilKwarter4")
                {
                    if(_hit.transform.name == "PilKwarter1")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter1Transform.position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter2")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter2Transform.position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter3")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter3Transform.position = holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter4")
                    {
                        PilKwartersDestroyed ++;
                        PilKwarter4Transform.position = holdingPos;
                    }
                }
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour
{
    private GameObject _interfaceWin;
    private GameObject _interfaceLose;
    private Transform _mouthTransform;
    private Transform _pilTransform;
    private Transform _pilHalf1Transform;
    private Rigidbody _pilHalf1Rigidbody;
    private Transform _pilHalf2Transform;
    private Rigidbody _pilHalf2Rigidbody;
    private Transform _pilKwarter1Transform;
    private Rigidbody _pilKwarter1Rigidbody;
    private Transform _pilKwarter2Transform;
    private Rigidbody _pilKwarter2Rigidbody;
    private Transform _pilKwarter3Transform;
    private Rigidbody _pilKwarter3Rigidbody;
    private Transform _pilKwarter4Transform;
    private Rigidbody _pilKwarter4Rigidbody;
    //private Vector3 _stagingPos = new Vector3(0,0,0);
    private Vector3 _holdingPos = new Vector3(0,0,-200);
    private int _pilKwartersDestroyed;
    private bool _won = false;
    private bool _timeUp = false;
    private bool _playing = true;
    private float _timer;

    private float _timeTakenDuringLerp = 4f;
    private float _distanceToMove =10f;
    private Vector3 _startScale = new Vector3(1,1,1);
    private Vector3 _endScale = new Vector3(4,4,1);
    private float _timeStartedLerping;
    private bool _isLerping = false;

    private void StartLerping()
    {
        _isLerping = true;
        _timeStartedLerping = Time.time;
    }

    void Awake ()
    {
        _interfaceWin = GameObject.Find("MiniGame1WinCanvas");
        _interfaceWin.SetActive(false);
        _interfaceLose = GameObject.Find("MiniGame1LoseCanvas");
        _interfaceLose.SetActive(false);
        _mouthTransform = GameObject.Find("Mouth").GetComponent<Transform>();
        _pilTransform = GameObject.Find("Pil").GetComponent<Transform>();
        _pilHalf1Transform = GameObject.Find("PilHalf1").GetComponent<Transform>();
        _pilHalf1Rigidbody = GameObject.Find("PilHalf1").GetComponent<Rigidbody>();
        _pilHalf2Transform = GameObject.Find("PilHalf2").GetComponent<Transform>();
        _pilHalf2Rigidbody = GameObject.Find("PilHalf2").GetComponent<Rigidbody>();
        _pilKwarter1Transform = GameObject.Find("PilKwarter1").GetComponent<Transform>();
        _pilKwarter1Rigidbody = GameObject.Find("PilKwarter1").GetComponent<Rigidbody>();
        _pilKwarter2Transform = GameObject.Find("PilKwarter2").GetComponent<Transform>();
        _pilKwarter2Rigidbody = GameObject.Find("PilKwarter2").GetComponent<Rigidbody>();
        _pilKwarter3Transform = GameObject.Find("PilKwarter3").GetComponent<Transform>();
        _pilKwarter3Rigidbody = GameObject.Find("PilKwarter3").GetComponent<Rigidbody>();
        _pilKwarter4Transform = GameObject.Find("PilKwarter4").GetComponent<Transform>();
        _pilKwarter4Rigidbody = GameObject.Find("PilKwarter4").GetComponent<Rigidbody>();
    }

    void Start ()
    {
        Vector3 _holdingPos = new Vector3(0,0,-200);
        _pilHalf1Transform.position = _holdingPos;
        _pilHalf2Transform.position = _holdingPos;
        _pilKwarter1Transform.position = _holdingPos;
        _pilKwarter2Transform.position = _holdingPos;
        _pilKwarter3Transform.position = _holdingPos;
        _pilKwarter4Transform.position = _holdingPos;
        StartLerping();
        _timer = Time.time + _timeTakenDuringLerp;
    }

    void Update ()
    {

        if(_playing)
        {
            if(Time.time > _timer)
            {
                _timeUp = true;
            }

            if(_pilKwartersDestroyed >= 3)
            {
                //win
                print("win");
                _interfaceWin.SetActive(true);
                _playing = false;
            }
            else if(_timeUp)
            {
                //lose
                print("lose");
                _interfaceLo;p;SetActive(true);
                _playing = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && _playing)
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast (ray, out _hit))
            {
                if(_hit.transform.name == "Pil")
                {
                    _pilHalf1Transform.position = _pilTransform.position;
                    _pilHalf1Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,1f),0);
                    _pilHalf1Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    _pilHalf2Transform.position = _pilTransform.position;
                    _pilHalf2Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,1f),0);
                    _pilHalf2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                    _pilTransform.position = _holdingPos;
                }

                else if(_hit.transform.name == "PilHalf1" || _hit.transform.name == "PilHalf2")
                {
                    if(_hit.transform.name == "PilHalf1")
                    {
                        _pilKwarter1Transform.position = _pilHalf1Transform.position;
                        _pilKwarter1Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(0f,1f),0);
                        _pilKwarter2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        _pilKwarter2Transform.position = _pilHalf1Transform.position;
                        _pilKwarter2Rigidbody.velocity = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,0f),0);
                        _pilKwarter2Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        _pilHalf1Transform.position = _holdingPos;
                    }

                    if(_hit.transform.name == "PilHalf2")
                    {
                        _pilKwarter3Transform.position = _pilHalf2Transform.position;
                        _pilKwarter3Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(0f,1f),0);
                        _pilKwarter3Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        _pilKwarter4Transform.position = _pilHalf2Transform.position;
                        _pilKwarter4Rigidbody.velocity = new Vector3(Random.Range(0f,1f), Random.Range(-1f,0f),0);
                        _pilKwarter4Rigidbody.AddRelativeTorque(Vector3.forward * Random.Range(-1f,1f) * 10f);
                        _pilHalf2Transform.position = _holdingPos;
                    }
                }

                else if(_hit.transform.name == "PilKwarter1" || _hit.transform.name == "PilKwarter2" || _hit.transform.name == "PilKwarter3" || _hit.transform.name == "PilKwarter4")
                {
                    if(_hit.transform.name == "PilKwarter1")
                    {
                        _pilKwartersDestroyed ++;
                        _pilKwarter1Transform.position = _holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter2")
                    {
                        _pilKwartersDestroyed ++;
                        _pilKwarter2Transform.position = _holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter3")
                    {
                        _pilKwartersDestroyed ++;
                        _pilKwarter3Transform.position = _holdingPos;
                    }

                    if(_hit.transform.name == "PilKwarter4")
                    {
                        _pilKwartersDestroyed ++;
                        _pilKwarter4Transform.position = _holdingPos;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(_isLerping)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / _timeTakenDuringLerp;

            _mouthTransform.transform.localScale = Vector3.Lerp (_startScale, _endScale, percentageComplete);

            if(percentageComplete >= 1f)
            {
                _isLerping = false;
            }
        }
    }
}

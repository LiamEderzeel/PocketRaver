using UnityEngine;
using System.Collections;

public class EffentController : MonoBehaviour {

    private enum Drugs {Neutral, MDMA, Cocaine, Wiet}
    private static Drugs _currentDrug;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        switch(_currentDrug)
        {
            case Drug.Neutral

                break;
            case Drug.MDMA

                break;
            case Drug.Cocaine

                break;
            case Drug.Wiet

                break;
        }
        public static void ToNeutral () {

            _currentDrug = Drug.Neutral;
        }

        public static void ToMDMA () {

            _currentDrug = Drug.MDMA;
        }

        public static void ToCocaine () {

            _currentDrug = Drug.Cocaine;
        }
    }

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
            case Drugs.Neutral:

                break;
            case Drugs.MDMA:

                break;
            case Drugs.Cocaine:

                break;
            case Drugs.Wiet:

                break;
        }
    }

    public static void ToNeutral () {

        _currentDrug = Drugs.Neutral;
    }

    public static void ToMDMA () {

        _currentDrug = Drugs.MDMA;
    }

    public static void ToCocaine () {

        _currentDrug = Drugs.Cocaine;
    }
}

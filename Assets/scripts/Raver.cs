using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {

    int lives = 3;
    // Use this for initialization
    void Start () {
        print(lives);
    }

    // Update is called once per frame
    void Update () {

    }
    void Lose_live () {
        lives --;
    }
}

using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {
    //private Sprite _spriteCharacter;
    //private Sprite _spriteEgg;

    private Sprite[] _sprites;
    public int _generatedRaver;
    private SpriteRenderer _spriteRenderer;
    public enum CharacterStates {Egg, Main}
    public CharacterStates CharacterState
    {
        get {return _characterState; }
        set {_characterState = value; }
    }
    private CharacterStates _characterState;
    private int lives = 3;

    void Awake ()
    {
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Start () {
        _sprites = Resources.LoadAll<Sprite>("sprites");
        if(_spriteRenderer.sprite == null)
        {
            SetCharacterEgg();
        }
    }

    void Update () {
        switch(_characterState)
        {
            case CharacterStates.Egg:
                break;
            case CharacterStates.Main:
                break;
        }
    }
    void Lose_live () {
        lives --;
    }

    public void SetCharacterEgg ()
    {
        _characterState = CharacterStates.Egg;
        _spriteRenderer.sprite = _sprites[0];
        _generatedRaver = 0;
    }

    public void SetCharacterMain ()
    {
        _characterState = CharacterStates.Main;
        _spriteRenderer.sprite = _sprites[_generatedRaver];
    }

    public void OpenEgg()
    {
        GenerateRaver();
        SetCharacterMain();
    }

    private void GenerateRaver ()
    {
        _generatedRaver = Random.Range(1,4);
    }
}

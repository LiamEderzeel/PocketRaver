using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {
    //private Sprite _spriteCharacter;
    //private Sprite _spriteEgg;

    private Sprite[] _sprites;
    private int _generatedRaver;
    private SpriteRenderer _spriteRenderer;
    private enum CharacterState {Egg, Main}
    private CharacterState _characterState;
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
            case CharacterState.Egg:
                break;
            case CharacterState.Main:
                break;
        }
    }
    void Lose_live () {
        lives --;
    }

    public void SetCharacterEgg ()
    {
        _characterState = CharacterState.Egg;
        _spriteRenderer.sprite = _sprites[0];
    }

    public void SetCharacterMain ()
    {
        _characterState = CharacterState.Main;
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

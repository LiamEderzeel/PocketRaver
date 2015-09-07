using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {
    private Sprite _spriteCharacter;
    private Sprite _spriteEgg;

    private SpriteRenderer _spriteRenderer;
    private enum CharacterState {Egg, Main}
    private CharacterState _characterState;
    private int lives = 3;

    void Awake ()
    {
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Start () {
        print(lives);
        _spriteCharacter = Resources.Load<Sprite>("sprites/character");
        _spriteEgg = Resources.Load<Sprite>("sprites/egg");
        if(_spriteRenderer.sprite == null)
        {
            _spriteRenderer.sprite = _spriteEgg;
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
        _spriteRenderer.sprite = _spriteEgg;
    }

    public void SetCharacterMain ()
    {
        _characterState = CharacterState.Main;
        _spriteRenderer.sprite = _spriteCharacter;
    }
}

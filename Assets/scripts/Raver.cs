using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {
    public Sprite _spriteCharacter;
    public Sprite _spriteEgg;

    private SpriteRenderer _spriteRenderer;
    private enum CharacterState {Egg, Main}
    private CharacterState _characterState;
    private int lives = 3;

    void Start () {
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        print(lives);
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

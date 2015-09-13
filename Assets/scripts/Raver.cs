using UnityEngine;
using System.Collections;

public class Raver : MonoBehaviour {
    //private Sprite _spriteCharacter;
    //private Sprite _spriteEgg;

    private Sprite[] _sprites;
    private RuntimeAnimatorController[] _animationControllers;
    public int _generatedRaver;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
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
        _animator = this.gameObject.GetComponent<Animator>();
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        

        _animationControllers = Resources.LoadAll<RuntimeAnimatorController>("animation/animation_controllers");
    }

    void Start () {
        _sprites = Resources.LoadAll<Sprite>("sprites/character");
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
        _animator.SetBool("clicked", false);
    }

    public void SetCharacterMain ()
    {
        _characterState = CharacterStates.Main;
        _animator.runtimeAnimatorController = _animationControllers[_generatedRaver];
        _animator.SetBool("clicked", true);
    }

    public void OpenEgg()
    {
        GenerateRaver();
        SetCharacterMain();
    }

    private void GenerateRaver ()
    {
        _generatedRaver = Random.Range(0,4);
    }
}

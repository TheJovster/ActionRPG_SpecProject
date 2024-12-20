using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Stats;
using UI;


namespace Player
{
    public class PlayerController : MonoBehaviour
{
    public string CharacterName { get; internal set; }
    private InputSystem_Actions _inputActions;
    private PlayerMotor _playerMotor;
    private PlayerCombatant _playerCombatant;
    private Camera _mainCamera;
    // declare the modifier scriptable object - although it makes no sense to me
    // private List<SO_Modifier> Modifiers = new List<SO_Modifier>();
    
    private int _currentLevel;

    [SerializeField] private CharacterClass _characterClass;
    
    
    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputSystem_Actions();
            _inputActions.Enable();
        }
    }

    private void Awake()
    {
        _playerMotor = GetComponent<PlayerMotor>();
        _playerCombatant = GetComponent<PlayerCombatant>();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _characterClass.CharacterExperience.RecalculateExpUntilNextLevel();
        _characterClass.RecalculateDerivedAttributes();
        
        UIManager.Instance.SetHealthImageFill();
        UIManager.Instance.SetManaImageFill();
    }

    private void Update()
    {

        if (_playerMotor && _inputActions.Player.Action.IsPressed())
        {
            MovePlayer();
        }

        if (_inputActions.Player.Stop.WasPressedThisFrame())
        {
            _playerMotor.StopMovement();
        }
        
        TestDamage();
        TestHeal();
        
        //redo modifiers in a way that makes sense to me        
        /*Modifiers.ForEach(m => {
            if (m.HasExpired(Time.deltaTime))
            {
                RemoveModifier(m);
                Destroy(m);
            }
        });*/
    }

    
    //basic implementation
    private void MovePlayer()
    {
        Vector2 mouseDelta = Mouse.current.position.ReadValue();
        Ray ray = _mainCamera.ScreenPointToRay(mouseDelta);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _playerMotor.SetDestination(hit.point);
        }
    }

    private void StopMovement()
    {
        _playerMotor.StopMovement();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void TestDamage()
    {
        if (_inputActions.Player.TakeDamage.WasPressedThisFrame())
        {
            _characterClass.TakeDamage(5);
        }
    }

    private void TestHeal()
    {
        if (_inputActions.Player.Heal.WasPressedThisFrame())
        {
            _characterClass.HealCharacter(5);
        }
    }

    public CharacterClass GetCharacterClass()
    {
        return _characterClass;
    }
    }
}


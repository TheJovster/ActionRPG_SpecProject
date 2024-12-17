using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Stats;


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
    
    

    
//keep these and refactor
    /*public float GetTotalValueForStat(SO_Stat Stat)
    {
        return Stat.BaseValue + Modifiers.Where(m => m.AffectedStat == Stat).Sum(m => m.ValueChange);
    }

    public float GetMaxValueForStat(SO_Stat Stat)
    {
        return Stat.BaseMaxValue + Modifiers.Where(m => m.AffectedStat == Stat).Sum(m => m.MaxValueChange);
    }
    
    public void AddModifier(SO_Modifier modifier)
    {
        Modifiers.Add(modifier);
    }

    public void RemoveModifier(SO_Modifier modifier)
    {
        Modifiers.Remove(modifier);
    }

    internal void Attack(Enemy enemy)
    {
        enemy.GetDamage(1f);
    }*/
}
}


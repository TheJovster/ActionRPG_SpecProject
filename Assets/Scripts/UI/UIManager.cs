using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Player;
using Unity.VisualScripting;
using Image = UnityEngine.UI.Image;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        private PlayerController _player;
        private float _playerCurrentHealth;
        private float _playerCurrentMana;
        private float _playerMaxHealth;
        private float _playerMaxMana;

        [SerializeField] private Image _healthImage;
        [SerializeField] private Image _manaImage; 

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            if (_player == null)
            {
                _player = FindFirstObjectByType<PlayerController>();
                RetrieveDerivedAttributes();
            }
        }

        private void Start()
        {
            RetrieveDerivedAttributes();
        }

        private void RetrieveDerivedAttributes()
        {
            _playerMaxHealth = _player.GetCharacterClass().DerivedAttributeList[0].DerivedAttributeMaxValue;
            _playerCurrentHealth = _player.GetCharacterClass().DerivedAttributeList[0].DerivedAttributeCurrentValue;
            _playerMaxMana = _player.GetCharacterClass().DerivedAttributeList[1].DerivedAttributeMaxValue;
            _playerCurrentMana = _player.GetCharacterClass().DerivedAttributeList[1].DerivedAttributeCurrentValue;
        }

        public void SetHealthImageFill()
        {
            RetrieveDerivedAttributes();
            _healthImage.fillAmount = _playerCurrentHealth / _playerMaxHealth;
            Debug.Log(_playerCurrentHealth);
            Debug.Log(_playerMaxHealth);
        }

        public void SetManaImageFill()
        {
            RetrieveDerivedAttributes();
            _manaImage.fillAmount = _playerCurrentMana / _playerMaxMana;
        }
    }
}


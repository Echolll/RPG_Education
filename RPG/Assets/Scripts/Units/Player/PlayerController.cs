using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RPG.Units.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerControls _controls;
        private StatsAssistant _stats;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.GameMap.FastAttack.performed += OnFastAttack;
            _controls.GameMap.StrongAttack.performed += OnStrongAttack;
        }


        private void OnFastAttack(CallbackContext context) 
        {
            Debug.Log("Слабый удар");
        }

        private void OnStrongAttack(CallbackContext context)
        {
            Debug.Log("Сильный удар");
        }

        private void Update()
        {
            OnMovement();
        }

        private void OnMovement()
        {
            var direction = _controls.GameMap.Movement.ReadValue<Vector2>();
            var velocity = new Vector3(direction.x, 0, direction.y);
            transform.position += velocity * _stats.GetSpeed() * Time.deltaTime;
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}

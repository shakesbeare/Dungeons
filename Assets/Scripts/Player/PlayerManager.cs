using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        inputManager.JoinPlayer(-1, -1, "Keyboard&Mouse", Keyboard.current);
        inputManager.JoinPlayer(-1, -1, "Gamepad", Gamepad.current);
    }
}

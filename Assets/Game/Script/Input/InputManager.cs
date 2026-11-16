using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction;
public class InputManager : MonoBehaviour, IPlayerActions
{
    // Variable untuk menyimpan reference object input action 
    private GameInputAction _inputAction;
    private void Awake()
    {
        // Membuat object GameInputAction dan menyimpan reference nya 
        // ke variable _inputAction 
        _inputAction = new GameInputAction();
        // Mengaktifkan input action 
        _inputAction.Enable();
        // Mengaktifkan action map Player 
        _inputAction.Player.Enable();
        // Memberi tahu bahwa kelas ini akan mendeteksi input dari 
        // action map Player 
        _inputAction.Player.SetCallbacks(this);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // contect.performed digunakan untuk mengecek apakah input ditekan 
        if (context.performed)
        {
            // Memunculkan log interact di console  
            // ketika input interact ditekan 
            Debug.Log("Interact");
        }
    }

    public UnityEvent<Vector2> OnMoveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        // Memanggil on move input ketika input move ditekan dan dilepas 
        // Event akan mengirimkan data arah input 
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
        Debug.Log("OnMove called");

        Vector2 movement = context.ReadValue<Vector2>();

        Debug.Log("Input value: " + movement);

        OnMoveInput?.Invoke(movement);
    }

    public UnityEvent<bool> OnSprintInput;
    public void OnSprint(InputAction.CallbackContext context)
    {
        // Mengecek apakah input ditekan 
        if (context.performed)
        {
            // Jika input ditekan maka trigger event OnSprintInput 
            // Mengirim data true 
            OnSprintInput?.Invoke(true);
            Debug.Log("Sprint Press");
        }
        // Mengecek apakah input dilepas 
        if (context.canceled)
        {
            // Jika input dilepas maka trigger event OnSprintInput 
            // Mengirim data false 
            OnSprintInput?.Invoke(false);
            Debug.Log("Sprint Not Press");
        }
    }

}
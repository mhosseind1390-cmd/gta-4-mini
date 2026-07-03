using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public Vector3 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical);
    }
    
    public Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        
        if (groundPlane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }
        
        return Vector3.zero;
    }
    
    public bool IsShootingPressed() => Input.GetMouseButton(0);
    public bool IsJumpPressed() => Input.GetKeyDown(KeyCode.Space);
    public bool IsInteractPressed() => Input.GetKeyDown(KeyCode.E);
    public bool IsEnterCarPressed() => Input.GetKeyDown(KeyCode.F);
    public bool IsPausePressed() => Input.GetKeyDown(KeyCode.Escape);
}

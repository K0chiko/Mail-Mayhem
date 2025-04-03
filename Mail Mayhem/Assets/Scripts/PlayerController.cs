using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private Vector2 move;
    Vector3 lastDirection;
    //Vector3 moveVector;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        

    }

    public void MovePlayer()
    {
        //  Vector3 movement = new Vector3(move.x, 0f, move.y);
        //  transform.Translate(movement * speed * Time.deltaTime, Space.World);
        //float moveX = Input.GetAxis("Horizontal")

        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Debug.Log(moveVector);
        if (moveVector != Vector3.zero)
        {           
            lastDirection = moveVector;

            transform.position = transform.position + speed * Time.deltaTime * moveVector;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVector), 0.1f); 
        }
        else
        {
            Debug.Log("last  " + lastDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lastDirection), 0f);
        }
    }
}

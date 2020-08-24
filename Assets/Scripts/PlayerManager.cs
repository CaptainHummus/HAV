using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidbody;

    private Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void AttachInput()
    {
        InputManager.INSTANCE.onMoveKeyPressed += Move;
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.velocity = movementVector;
    }

    private void Move(Vector3 input)
    {
        
    }
}

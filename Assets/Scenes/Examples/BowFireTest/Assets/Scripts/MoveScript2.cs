using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript2 : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private int counter;
    public int counterMax;

    void Awake()
    {
        counterMax = 200;
    }

    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
        if (counter > counterMax)
        {
            counter = 0;
            direction.x *= -1;
        }
        counter++;
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rigidbody2D.velocity = movement;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    //1. access level: public or private
    //2. type: int (e.g., 2, 4, 123, 3456, etc.), float (e.g, 2.5, 3.67, etc.)
    //3. name: (1) start w/ lowercase (2) if it is multiple words, then the other words start with uppercase and written together
    //4. optional: give it an initial value
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private int lives;
    public GameObject bullet;

    float xBorderValue = 11.5f;
    float maximumValueY = 0;
    float minimumValueY = -4f;

    void Start()
    {
        speed = 6f;
        lives = 3;
    }

    void Update()
    {
        Moving();
        Shooting();
    }
    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(transform.position.x + horizontalInput,
            Mathf.Clamp(transform.position.y + verticalInput, minimumValueY, maximumValueY));

        // I changed the way teleporting between sides of the screen works,
        //  since a bug occurred where, if the player posiion exceeded either boundary, he'd get stuck in a loop of swapping sides.
        if (transform.position.x > xBorderValue)
        {
            transform.position = new Vector3(-xBorderValue, transform.position.y, 0);
        }
        else if (transform.position.x < -xBorderValue)
        {
            transform.position = new Vector3(xBorderValue, transform.position.y, 0);
        }
    }
    void Shooting()
    {
        //if SPACE key is pressed create a bullet; what is a bullet?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet object at my position with my rotation
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0),
            Quaternion.identity);
        }
    }

}

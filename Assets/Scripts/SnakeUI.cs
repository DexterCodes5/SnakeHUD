using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeUI : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    public Transform segmentImage;
    public Vector2 direction = Vector2.right;
    private Vector2 input;
    public int initialSize = 4;

    public Swipe swipeControls;

    public Canvas canvas;
    //int frameCount = 0;

    public static int lives = 3;

    public static int[] scores = new int[10];

    public AudioSource appleCollectSound;


    // Start is called before the first frame update
    private void Start()
    {
        ResetState();

    }

    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || swipeControls.SwipeUp)
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || swipeControls.SwipeDown)
            {
                input = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || swipeControls.SwipeRight)
            {
                input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || swipeControls.SwipeLeft)
            {
                input = Vector2.left;
            }
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            direction = input;
        }

        /*
        frameCount++;

        if (frameCount == 2)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }
            frameCount = 0;
        }
        */
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        
        if (direction.x == 1)
        {
            x += 20;
        }
        else if (direction.x == -1)
        {
            x -= 20;
        }

        if (direction.y == 1)
        {
            y += 20;
        }
        else if (direction.y == -1)
        {
            y -= 20;
        }
        
        transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentImage, canvas.transform);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector2.right;

        transform.position = new Vector3(559, 1141, 0);


        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        
        
        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);
        
        
        
        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Food"))
        {
            appleCollectSound.Play();
            if (AppleCounter.appleValue == 9)
            {
                lives = 3;
                SceneManager.LoadScene(2);
            }
            Grow();
            AppleCounter.appleValue += 1;
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            if (lives == 0)
            {
                lives = 3;
                SceneManager.LoadScene(3);
            }
            
            ResetState();
            Debug.Log(lives);
        }
    }

}

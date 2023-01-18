using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float laneChangeSpeed = 5f;
    public Transform[] lanes; // array of transforms representing different lanes
    public int currentLane = 1; // current lane the player is on, default is the center lane

    private bool canChangeLanes = true; // flag to prevent the player from changing lanes too quickly

    public GameObject gameOverCanvas; // reference to the Game Over canvas
    public string tagToCheck = "Untagged"; // The tag to check for collision or trigger
    public TextMeshProUGUI finalScore;

    public bool isPlayerAlive;

    [Header("Audio")]
    public AudioClip audioClips; // an array of audio clips
    private AudioSource audioSource; // the audio source component

    public TextMeshProUGUI inputString;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isPlayerAlive = true;
        gameOverCanvas.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips;
        audioSource.Play();
    }

    void Update()
    {
        //float x = Input.GetAxisRaw("Horizontal");

        if (canChangeLanes)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputString.text = "Input: '<-' / 'A'";
                ChangeLanes(-1);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                inputString.text = "Input: '->' / 'D'";
                ChangeLanes(1);
            }
            else
            {
                inputString.text = "Input: No input";
            }
        }
    }

    /* 
    * This function changes the player's lane based on the input direction
    * @param direction - the direction of lane change (-1 for left, 1 for right)
    */
    void ChangeLanes(int direction)
    {
        if (currentLane + direction >= 0 && currentLane + direction < lanes.Length)
        {
            currentLane += direction;
            StartCoroutine(MoveToLane(lanes[currentLane]));
        }
    }

    /*
    * This function moves the player to the target lane over time
    * @param targetLane - the target lane to move the player to
    */
    IEnumerator MoveToLane(Transform targetLane)
    {
        canChangeLanes = false;
        //while (Vector3.Distance(targetLane.position, transform.position) > 0.05f)
        while (Mathf.Abs((targetLane.position - transform.position).x) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLane.position, laneChangeSpeed * Time.deltaTime);
            yield return null;
        }
        canChangeLanes = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
        {
            gameOverCanvas.SetActive(true);
            isPlayerAlive = false;
            finalScore.text = "Score:" + Score.instance.GetCurrentScore().ToString("F2");
            audioSource.Stop();
        }
    }
}

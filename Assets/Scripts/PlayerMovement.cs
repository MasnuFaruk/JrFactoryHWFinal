using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float horizontalSpeed;

    private bool isGameBegin = false;
    private bool isLevelFinished = false;
    private bool isGameOver = false;

    [Header("Texts")]
    [SerializeField] GameObject levelBeginText;
    [SerializeField] GameObject levelEndText;

    [Header("Player Movement Limits")]
    [SerializeField] float minX = -3.473f;
    [SerializeField] float maxX = 3.483f;

    //Mobile Control Variables
    Vector2 startPos;
    
    Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        levelEndText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver&&!isLevelFinished&&!isGameBegin&&(Input.GetMouseButtonDown(0)|| Input.touchCount > 0))
        {
            isGameBegin = true;
            levelBeginText.SetActive(false);
        }
        if (isGameBegin)
        {
            
            MoveForward();
        if(Input.GetMouseButton(0))
            {
                MoveHorizontal();
            }
            if (Input.touchCount > 0)
            {
                MoveHorizontalMobile();
            }
        }
       
    }

    void MoveForward()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    void MoveHorizontal()
    {
        float xValue=transform.position.x+ Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        float posX=Mathf.Clamp(xValue,minX,maxX);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    void MoveHorizontalMobile()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            startPos = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
        {
            endPos = touch.position;
            decimal xValue = (decimal)transform.position.x + ((decimal)(endPos.x - startPos.x) * (decimal)Time.deltaTime * (decimal)horizontalSpeed*(decimal)0.0000000000000000000000000000001);
            float posX = Mathf.Clamp((float)xValue, minX, maxX);
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            startPos = endPos;
        }
    }

    public void FinishedLevel()
    {
        isLevelFinished = true;
        isGameBegin = false;
        levelEndText.SetActive(true);
    }
    public void GamerOver()
    {
        isGameOver = true;
        isGameBegin = false;
    }
}

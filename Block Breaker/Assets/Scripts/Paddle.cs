using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthUnits = 16f;
    [SerializeField] private float xMin = 1f;    
    [SerializeField] private float xMax = 15f;

    private Vector3 paddlePos;

    // Start is called before the first frame update
    void Start()
    {
        paddlePos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        updateCurrentPos();
    }

    private void updateCurrentPos()
    {
        paddlePos.x = getXPos();
        paddlePos.y = getYPos();
        transform.position = paddlePos;
    }

    private float getXPos()
    {
        float xPos = Input.mousePosition.x / Screen.width * screenWidthUnits;
        return Mathf.Clamp(xPos, xMin, xMax);
    }
    private float getYPos()
    {
        return transform.position.y;
    }
}

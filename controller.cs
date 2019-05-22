using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Game2048;
using System;

public class Controller : MonoBehaviour
{
    public Button buttonStart;
    public Text textMessage;
    Model model = new Model(4);

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        textMessage.text = "welcome to my 2048";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float nx = touchDeltaPosition.x;
            float ny = touchDeltaPosition.y;
            if (Math.Abs(nx) > Math.Abs(ny))
            {
                if (nx < 10)
                    model.Left();
                else
                    model.Right();
            }

            else
            {
                if (ny < 10)
                    model.Down();
                else
                    model.Up();
            }


            Show();
            if (model.IsGameOver())
                textMessage.text = "Game over";


        }
    }
    void Show()
    {
        for (int x = 0; x < model.size; x++)
            for (int y = 0; y < model.size; y++)
            {
                ShowButtonText("b" + x + y, model.GetMap(x, y));



            }


        //or here?"?? XD
    }

    private void ShowButtonText(string name, int number)
    {
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        text.text = number == 0 ? " " : number.ToString();


        //here we need to change button color
    }

    //color need fix

    public void clickButtonStart()
    {
        textMessage.text = "Use swipes for move";
        model.Start();
        Show();

    }
}







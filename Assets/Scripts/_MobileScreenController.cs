using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MobileScreenController : MonoBehaviour
{
    //Diger classlara eri�im sa�lama
    public static _MobileScreenController Instance { get; set; }

    [HideInInspector] // �nspectorde gizledim
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    public Vector2 swipeDelta, startTouch;
    
    //Kullan�c�n�n ekran� kayd�rma uzunlu�u
    private const float deadZone = 50;


    private void Awake()
    {

        Instance = this;
    }

    private void Update()
    {
        //Booleanlar� s�f�rl�yoruz
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeDown = false;
        swipeUp = false;

        //Bilgisayar Kontrolleri
        #region PC Controls
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        #endregion
        //Mobil Kontrolleri
        #region Mobile Controls
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = Vector2.zero;
                swipeDelta = Vector2.zero;
            }

        }
        #endregion

        // Mesafeyi hesapl�yoruz
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Mobil i�in
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // PC i�in
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }


        }

        // swipeDelta, deadZone den k���k m� ?
        if (swipeDelta.magnitude > deadZone)
        {
            // E�er deadzone'yi ge�tiysek
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Sol mu sa� m�
                if (x < 0)
                {
                    // Sol
                    swipeLeft = true;
                }
                else
                {
                    // Sa�
                    swipeRight = true;
                }
            }
            else
            {
                // Yukar� m� a�a�� m�
                if (y < 0)
                {
                    // A�a��
                    swipeDown = true;
                }
                else
                {
                    // Yukar�
                    swipeUp = true;
                }
            }
            //Touch' � s�f�rl�yoruz
            startTouch = Vector2.zero;
            swipeDelta = Vector2.zero;
        }
    }
}


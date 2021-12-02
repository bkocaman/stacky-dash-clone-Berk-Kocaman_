using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MobileScreenController : MonoBehaviour
{
    //Diger classlara eriþim saðlama
    public static _MobileScreenController Instance { get; set; }

    [HideInInspector] // Ýnspectorde gizledim
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    public Vector2 swipeDelta, startTouch;
    
    //Kullanýcýnýn ekraný kaydýrma uzunluðu
    private const float deadZone = 50;


    private void Awake()
    {

        Instance = this;
    }

    private void Update()
    {
        //Booleanlarý sýfýrlýyoruz
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

        // Mesafeyi hesaplýyoruz
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Mobil için
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // PC için
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }


        }

        // swipeDelta, deadZone den küçük mü ?
        if (swipeDelta.magnitude > deadZone)
        {
            // Eðer deadzone'yi geçtiysek
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Sol mu sað mý
                if (x < 0)
                {
                    // Sol
                    swipeLeft = true;
                }
                else
                {
                    // Sað
                    swipeRight = true;
                }
            }
            else
            {
                // Yukarý mý aþaðý mý
                if (y < 0)
                {
                    // Aþaðý
                    swipeDown = true;
                }
                else
                {
                    // Yukarý
                    swipeUp = true;
                }
            }
            //Touch' ý sýfýrlýyoruz
            startTouch = Vector2.zero;
            swipeDelta = Vector2.zero;
        }
    }
}


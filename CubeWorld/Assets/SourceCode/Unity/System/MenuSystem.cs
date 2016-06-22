using UnityEngine;
using System.Collections.Generic;

public class MenuSystem
{
    public static GUISkin skin;

    public delegate void OnPressedDelegate();

    private static int cantidadBotones;

    private static int focusedButton = 0;

    private static bool ignoreAxis;
    private static bool ignoreButton;

    private static List<OnPressedDelegate> delegates = new List<OnPressedDelegate>();

    public static float vAxis = 0.0f;
    public static bool actionButtonDown = false;
    public static bool useKeyboard = true;

    public static void ResetFocus()
    {
        focusedButton = 0;
    }

    public static void BeginMenu(string text)
    {
        cantidadBotones = 0;
        delegates.Clear();

        //Screen.showCursor = false;
        GUI.skin = skin;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400));

        GUI.Box(new Rect(0, 0, 400, 400), text);
    }

    public static void Button(string text, OnPressedDelegate onPressed)
    {
        delegates.Add(onPressed);

        GUI.SetNextControlName("Boton" + cantidadBotones.ToString());

        if (GUI.Button(new Rect(10, 40 + 30 * 2 * cantidadBotones, 380, 30), text))
            onPressed();

        cantidadBotones++;
    }

    public static string TextField(string text)
    {
        GUI.SetNextControlName("Boton" + cantidadBotones.ToString());

        text = GUI.TextField(new Rect(10, 40 + 30 * 2 * cantidadBotones, 380, 30), text);

        cantidadBotones++;

        return text;
    }

    public static void LastButton(string text, OnPressedDelegate onPressed)
    {
        delegates.Add(onPressed);

        GUI.SetNextControlName("Boton" + cantidadBotones.ToString());

        if (GUI.Button(new Rect(10, 400 - 70, 380, 30), text))
            onPressed();

        cantidadBotones++;
    }

    public static void EndMenu()
    {
        GUI.EndGroup();

        if (useKeyboard)
        {
            if (cantidadBotones > 0 && GUIUtility.hotControl == 0)
            {
                if (!ignoreAxis && vAxis != 0)
                {
                    if (vAxis > 0)
                        focusedButton--;
                    else if (vAxis < 0)
                        focusedButton++;

                    ignoreAxis = true;
                }

                if (vAxis == 0)
                    ignoreAxis = false;

                if (focusedButton < 0)
                    focusedButton = cantidadBotones - 1;

                if (focusedButton >= cantidadBotones)
                    focusedButton = 0;

                GUI.FocusControl("Boton" + focusedButton.ToString());

                if (!ignoreButton && actionButtonDown)
                {
                    ignoreButton = true;
                    delegates[focusedButton]();
                }
                else if (!actionButtonDown)
                {
                    ignoreButton = false;
                }
            }
        }
    }
}

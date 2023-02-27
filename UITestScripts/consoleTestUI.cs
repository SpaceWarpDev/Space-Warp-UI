using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class consoleTestUI : MonoBehaviour
{

    public GUIStyle boxStyle;
    public GUISkin boxSkin;

    static bool loaded = true;
    private bool drawUI = true;
    private Rect windowRect;
    private int windowWidth = 700;
    private int windowHeight = 350;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        windowWidth = (int)(Screen.width * 0.5f);
        windowHeight = (int)(Screen.height * 0.5f);
        windowRect = new Rect((Screen.width * 0.15f), (Screen.height * 0.15f),
        0, 0);
    }

    private void OnGUI()
    {
        ///boxStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 0.5f));
        GUI.skin = boxSkin;
        if (!drawUI)
        {

            return;
        }

        int controlID = GUIUtility.GetControlID(FocusType.Passive);
        string header = $"spacewarp.console";
        GUILayoutOption width = GUILayout.Width((float)(windowWidth * 0.8));
        GUILayoutOption height = GUILayout.Height((float)(windowHeight * 0.8));

        windowRect = GUILayout.Window(controlID, windowRect, DrawConsole, header, width, height);
    }
    private List<string> debugMessages = new List<string>();

    

    private static Vector2 scrollPosition;

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    private void DrawConsole(int windowID)
    {
        boxStyle = GUI.skin.GetStyle("Box");
        
        
        GUILayout.BeginVertical();
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true);

        foreach (var debugMessage in debugMessages)
        {
            GUILayout.Label(debugMessage);
        }

        GUILayout.EndScrollView();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Close"))
        {
            drawUI = false;
        }

        if (GUILayout.Button("Clear"))
        {
        }

        if (GUILayout.Button("Clear Control Locks"))
        {
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUI.DragWindow(new Rect(0, 0, 10000, 500));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.C))
        {
            drawUI = !drawUI;
        }
        debugMessages.Add("[LOG] [Modname] BALLS");
    }
}

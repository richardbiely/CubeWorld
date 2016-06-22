using UnityEngine;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour 
{
    public int lastFps = 0;

    private int frames;
    private float lastTime;

    public PlayerUnity playerUnity;

    public enum State
    {
        NORMAL,
        INVENTORY
    }

    public State ActiveState
    {
        get { return state; }
        set
        {
            if (value != state)
            {
                activeGUIState.OnDeactivated();
                state = value;
                activeGUIState = availableStates[state];
                activeGUIState.OnActivated();
            }
        }
    }

    private State state;
    private GUIState activeGUIState;
    private Dictionary<State, GUIState> availableStates = new Dictionary<State, GUIState>();

    void Start()
    {
        lastTime = Time.realtimeSinceStartup;

        availableStates[State.NORMAL] = new GUIStatePlayerNormal(this);
        availableStates[State.INVENTORY] = new GUIStatePlayerInventory(this);

        state = State.NORMAL;
        activeGUIState = availableStates[State.NORMAL];
        activeGUIState.OnActivated();
    }

    void Update()
    {
        UpdateFPS();

        if (playerUnity.gameManagerUnity.State == GameManagerUnity.GameManagerUnityState.GAME)
            activeGUIState.ProcessKeys();
    }

    private void UpdateFPS()
    {
        frames++;

        if (Time.realtimeSinceStartup - lastTime >= 1.0f)
        {
            lastFps = (int) ((float)frames / (Time.realtimeSinceStartup - lastTime));
            lastTime = Time.realtimeSinceStartup;
            frames = 0;
        }
    }

    public void EnterInventory()
    {
        GameManagerUnity.ReleaseCursor();
        ActiveState = State.INVENTORY;
    }

    public void ExitInventory()
    {
        GameManagerUnity.LockCursor();
        ActiveState = State.NORMAL;
    }

    void OnGUI() 
    {
        playerUnity.DrawUnderWaterTexture();

        if (playerUnity.gameManagerUnity.State == GameManagerUnity.GameManagerUnityState.GAME ||
            playerUnity.gameManagerUnity.State == GameManagerUnity.GameManagerUnityState.PAUSE)
            activeGUIState.Draw();
	}
}

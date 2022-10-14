using System.Collections;
using System.Collections.Generic;
using rosAirHockyinData = AirHockeyGameData; //change to ros message when jery finished
using rosAirHockyreturnData = AirHockeyGameData; // change to ros message when jery finished
using UnityEngine.Events;
using UnityEngine;

public class gameMgr : MonoBehaviour
{
    public static gameMgr Inst;
    public AirHockeyGameData currentData;
    public UnityEvent updateevent;
    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentData = new AirHockeyGameData();
        if (updateevent == null)
            updateevent = new UnityEvent();
        updateevent.AddListener(updateTimescale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateTimescale()
    {
        int value = Mathf.Clamp(currentData.startStop, 0, 1); //suppose it is inclusive
        Time.timeScale = value;
    }

    public rosAirHockyreturnData tryUpdate(rosAirHockyinData inData)
    {
        currentData = inData;
        updateevent.Invoke();
        return currentData;
    }

}

public struct AirHockeyGameData
{
    public AirHockeyGameData(int num = 1)
    {
        ballSpeed = num; //done
        ballRadius = num; //done
        goalSize = num; //done
        friction = 0.4f; //done
        buttonSpeed = num; //not sure where to put it
        capture = 0; //not sure what this means
        startStop = 0; //1 start 0 stop done
    }
    public float ballSpeed;
    public float ballRadius;
    public float goalSize;
    public float friction;
    public float buttonSpeed; 
    public int capture;
    public int startStop;

    //implicit converision when jery finished 
}


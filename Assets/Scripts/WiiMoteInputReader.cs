using UnityEngine;
using System.Collections;

public class WiiMoteInputReader : MonoBehaviour {

    WiimoteReceiver receiver;

    float nunchukX;
    float nunchukY;
    float wiimoteA;    
    int nrOfJumps = 0;

	void Start () {

        Debug.Log("Running thangs!");
        receiver = WiimoteReceiver.Instance;
        receiver.connect();
    }
		
	void Update () {         
        Wiimote mote = receiver.wiimotes[1];
        nunchukX = mote.NUNCHUK_JOY_X;
        nunchukY = mote.NUNCHUK_JOY_Y;

        if (nunchukX < 0.01f && nunchukX > 0.0f)
        {
            nunchukX = 0.0f;
        }
        if (nunchukX > -0.01f && nunchukX < 0.0f)
        {
            nunchukX = 0.0f;
        }

        if (nunchukY < 0.01f)
        {
            nunchukY = 0.0f;
        }

        Debug.Log(nunchukX + ", " + nunchukY);        
	}


    public float getX() { return nunchukX; }
    public float getY() { return nunchukY; }
    
}

using UnityEngine;
using System.Collections;

public class WiiMoteInputReader : MonoBehaviour {

    WiimoteReceiver receiver;

    float nunchukX;
    float nunchukY;
    float wiimoteA;

	void Start () {

        Debug.Log("Running thangs!");
        receiver = WiimoteReceiver.Instance;
        receiver.connect();
    }
		
	void Update () {         
        Wiimote mote = receiver.wiimotes[1];
        nunchukX = mote.NUNCHUK_JOY_X;
        nunchukY = mote.NUNCHUK_JOY_Y;

        wiimoteA = mote.BUTTON_A;

        Debug.Log(nunchukX + ", " + nunchukY);        
	}

    public float getX() { return nunchukX; }
    public float getY() { return nunchukY; }
    public float getJump() { return wiimoteA; }
}

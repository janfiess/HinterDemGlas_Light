/*
	This script reads the color values of Unity software lights in realtime (Update function) 
	and translates the RGB values to DMX devices
	The Unity software lights' colors are driven by the Animator
 */


using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using ArtNet;
using UnityEngine.UI;

public class Dmx_Configurator : MonoBehaviour
{
    public byte[] DMXData = new byte[512];
    public InputField ip_textfield;

    ArtNet.Engine ArtEngine;
	Animator animator;

	// LED white
	public Light softwareLight_white; // this color will be transmitted to LED 1 (and 2)
	public GameObject softwareLight_white_debug;
	int port_led_white = 0; // DMX 1
	Color prevLed_white_Color;


	// LED red
	public Light softwareLight_red; 
	public GameObject softwareLight_red_debug;
	int port_led_red = 3;            // DMX 4
	Color prevLed_red_Color;



	// LED camera
	public Light softwareLight_camera; 
	public GameObject softwareLight_camera_debug;
	int port_led_camera = 8;            // DMX 9
	Color prevLed_camera_Color;




    void Start()
    {
        for (int i = 0; i < DMXData.Length; i++)
        {
            DMXData[i] = (byte)(0);
        }

        // Artnet sender / client
        string ipAddress = ip_textfield.text;
        if(ip_textfield.text == "") ipAddress = ip_textfield.placeholder.GetComponent<Text>().text;
        print(ipAddress);
        ArtEngine = new ArtNet.Engine("Open DMX Etheret", ipAddress);
        ArtEngine.Start();

		animator = GetComponent<Animator> ();
    }

		// UI buttons
	public void DMX_RightCombination(){	
		animator.SetTrigger ("trg_RightCombination");
	}

	public void DMX_WrongCombination(){
		animator.SetTrigger ("trg_WrongCombination");
	}

	public void DMX_Mood1(){
		animator.SetTrigger ("trg_Mood1");
	}

	public void DMX_Mood2(){
		animator.SetTrigger ("trg_Mood2");
	}

	public void DMX_Mood3(){
		animator.SetTrigger ("trg_Mood3");
	}

	public void DMX_Mood4(){
		animator.SetTrigger ("trg_Mood4");
	}

	public void DMX_Mood5(){
		animator.SetTrigger ("trg_Mood5");
	}

	public void DMX_Mood6(){
		animator.SetTrigger ("trg_Mood6");
	}

	public void DMX_Mood7(){
		animator.SetTrigger ("trg_Mood7");
	}

	public void DMX_Mood8(){
		animator.SetTrigger ("trg_Mood8");
	}

	public void DMX_Mood9(){
		animator.SetTrigger ("trg_Mood9");
	}

	public void DMX_Mood10(){
		animator.SetTrigger ("trg_Mood10");
	}

	public void DMX_Mood11(){
		animator.SetTrigger ("trg_Mood11");
	}

	public void DMX_Mood12(){
		animator.SetTrigger ("trg_Mood12");
	}

	public void DMX_Mood13(){
		animator.SetTrigger ("trg_Mood13");
	}

	public void DMX_Mood14(){
		animator.SetTrigger ("trg_Mood14");
	}

	public void DMX_Mood15(){
		animator.SetTrigger ("trg_Mood15");
	}

	public void DMX_Mood16(){
		animator.SetTrigger ("trg_Mood16");
	}

	public void DMX_Mood17(){
		animator.SetTrigger ("trg_Mood17");
	}

	public void DMX_Mood18(){
		animator.SetTrigger ("trg_Mood18");
	}

	public void DMX_Mood19(){
		animator.SetTrigger ("trg_Mood19");
	}

	public void DMX_Mood20(){
		animator.SetTrigger ("trg_Mood20");
	}

	public void DMX_Mood21(){
		animator.SetTrigger ("trg_Mood21");
	}

	public void DMX_Mood22(){
		animator.SetTrigger ("trg_Mood22");
	}

	public void DMX_Mood23(){
		animator.SetTrigger ("trg_Mood23");
	}

	public void Toggle_white(){
		if (softwareLight_white.color.r < 0.1f){
			animator.SetTrigger ("trg_white");
		} 
		else if (softwareLight_white.color.r >= 0.1f){
			animator.SetTrigger ("trg_whiteOff");
		} 
	}

	public void Toggle_red(){
		if (softwareLight_red.color.r < 0.1f){
			animator.SetTrigger ("trg_red");
		} 
		if (softwareLight_red.color.r >= 0.1f){
			animator.SetTrigger ("trg_redOff");
		} 
	}



	public void Toggle_white_red(){
		if (softwareLight_red.color.r < 0.1f){
			animator.SetTrigger ("trg_white_red");
		} 
		else if (softwareLight_red.color.r >= 0.1f){
			animator.SetTrigger ("trg_white_redOff");
		} 
	}

	public void Toggle_camera(){
		if (softwareLight_camera.color.r < 0.1f){
			animator.SetTrigger ("trg_camera");
		} 
		else if (softwareLight_camera.color.r >= 0.1f){
			animator.SetTrigger ("trg_cameraOff");
		} 
	}



	void Update(){
	// First change DMX array values (DMX Port, value [0..255]));
	// Then send it away.
	// Pick the current color of the light in the scene and send it to real LEDs via Artnet

		if (softwareLight_white.color != prevLed_white_Color) {

			DMXData[port_led_white] = (byte)(softwareLight_white.color.r * 255);


			// see color also on a gameobject in scene
			softwareLight_white_debug.GetComponent<Renderer>().material.color = softwareLight_white.color;
			prevLed_white_Color = softwareLight_white.color;
		}


		if (softwareLight_red.color != prevLed_red_Color) {
			DMXData[port_led_red] = (byte)(softwareLight_red.color.r * 255);

			// see color also on a gameobject in scene
			softwareLight_red_debug.GetComponent<Renderer>().material.color = softwareLight_red.color;
			prevLed_red_Color = softwareLight_red.color;
		}

		if (softwareLight_camera.color != prevLed_camera_Color) {
			DMXData[port_led_camera] = (byte)(softwareLight_camera.color.r * 255);

			// see color also on a gameobject in scene
			softwareLight_camera_debug.GetComponent<Renderer>().material.color = softwareLight_camera.color;
			prevLed_camera_Color = softwareLight_camera.color;
		}


		ArtEngine.SendDMX(0, DMXData, DMXData.Length);
	}

}
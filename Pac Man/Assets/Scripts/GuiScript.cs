using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiScript : MonoBehaviour {

    float native_width = 1920;
    float native_height = 1080;

    private bool is_dead = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (NewBehaviourScript.num_lives > 0) {
            Time.timeScale = 1;
        }
        else {
            Time.timeScale = 0;
            if (NewBehaviourScript.score > NewBehaviourScript.highest_score) {
                NewBehaviourScript.highest_score = NewBehaviourScript.score;
            }
            is_dead = true;
        }

    }

    string calculateScore(int cur_score) {
        string temp = cur_score.ToString();
        int temp_length = temp.Length;
        while(temp_length < 5) {
            temp = "0" + temp;
            temp_length++;
        }
        string to_return = temp[0] + "\n" + temp[1] + "\n" + temp[2] + "\n" + temp[3] + "\n" + temp[4];
        return to_return;
    }

    void OnGUI() {
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

        GUI.Label(new Rect(native_width / 2-500, native_height / 2-500, 400, 150), "Game\nScore\n" + calculateScore(NewBehaviourScript.score));
        GUI.Label(new Rect(native_width / 2 + 500, native_height / 2 - 500, 400, 150), "High\nScore\n" + calculateScore(NewBehaviourScript.highest_score));
        GUI.Label(new Rect(native_width/2 -503, native_height/2 +375,400,150),"Lives");

        if (is_dead == true) {
            if (GUI.Button(new Rect(native_width/2-50,native_height/2-50, 100,100), "Replay Game?")) {
                is_dead = false;
                NewBehaviourScript.num_lives = 3;
                NewBehaviourScript.score = 0;
                SceneManager.LoadScene("Game");
            }
        }

    }
}

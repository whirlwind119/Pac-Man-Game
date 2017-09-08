using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class CreateLevelScript : MonoBehaviour {
	public GameObject wall;
	public GameObject pellet;
	public GameObject player;
    public GameObject ghost;
    // Use this for initialization
    void Start () {
		Load_file ("Assets/level_design.txt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void Load_file(string filename){
		string line;
		bool pellets = false;
		float y = 0;

		StreamReader reader = new StreamReader (filename, Encoding.Default);

		using (reader) {
			do{
				line = reader.ReadLine();
				y++;
				if (line != null){
					if (line == "pellets"){
						break;

					}

					create_row(line, y);
					
				}
			}while (line!= null);
			reader.Close ();

		}


	}

	private void create_row(string line, float rowNum){
		for (int i = 0; i < line.Length; i++) {
			if (line [i] == '1') {
				Instantiate (pellet, new Vector2 ((float)i, rowNum), Quaternion.identity);
				continue;
			} else if (line [i] == '2') {
				Instantiate (player, new Vector2 ((float)i, rowNum), Quaternion.identity);
			} else if (line [i] == '3')
            {
                Instantiate (ghost, new Vector2 (i, rowNum), Quaternion.identity);
            }

			else {
				Instantiate (wall, new Vector2 ((float)i, rowNum), Quaternion.identity);
			}
		}
	}
}

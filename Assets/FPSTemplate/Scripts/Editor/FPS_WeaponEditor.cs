//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script is ParkingManager.cs Editor\Inspector layout


using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FPS_Weapon))][CanEditMultipleObjects]
public class FPS_WeaponEditor : Editor
{
	
	Texture2D MainIcon;
	bool sniper;
	void Awake ()
	{
		MainIcon = Resources.Load ("FPS_VOL_1", typeof(Texture2D)) as Texture2D;
	}


	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();



		EditorGUILayout.Space ();

		GUI.color = Color.green;
		EditorGUILayout.Space ();
		GUILayout.FlexibleSpace ();
		EditorGUILayout.HelpBox ("FPS Template Weapon", MessageType.None);
		GUILayout.FlexibleSpace ();
		EditorGUILayout.Space ();
		GUI.color = Color.white;
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label (new GUIContent ("", MainIcon, ""), GUILayout.Height (140), GUILayout.Width (300));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Settings", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("rocketModel"),
			new GUIContent ("Rocket Model", "Drag rocket model from hierarchy"), true);
		EditorGUILayout.Space ();

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("rocketPrefab"),
			new GUIContent ("Rocket Prefab", "Drag rocket prefab from project files"), true);
		EditorGUILayout.Space ();

 		EditorGUILayout.PropertyField (serializedObject.FindProperty ("weaponModel"),
			new GUIContent ("Weapon Model", "Drag Weapon Model Here"), true);

		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("fireShootSpot"),
			new GUIContent ("Fire Shoot Point", "Drag Fire Shoot Point GameObject Here"), true);
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("fireRate"),
			new GUIContent ("Fire Rate", "Weapon Fire Rate"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("reloadTime"),
			new GUIContent ("Reload Time", "Weapon Reload Time"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Power"),
			new GUIContent ("Force Power", "Weapon Force Power"), true);
		//----------------------------------------------------------------------------------

		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Sounds", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("fireSound"),
			new GUIContent ("Fire Sound", "Assign Fire Sound Clip"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("reloadSound"),
			new GUIContent ("Reload Sound", "Assign Reload Sound Clip"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("fireEndSound"),
			new GUIContent ("Fire End Sound", "This audio will be played in end of the each firind"), true);
		
		//----------------------------------------------------------------------------------


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Crosshairs", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;



		/*EditorGUILayout.PropertyField (serializedObject.FindProperty ("Sniper"),
			new GUIContent ("", "Is Sniper Crosshair"), true);*/
		

			EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairImage"),
				new GUIContent ("Texture Normal", "Drag Crosshair Texture Here"), true);
		
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairHited"),
				new GUIContent ("Texture Hit", "Drag Crosshair Hited  Texture Here"), true);
		
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairMin"),
			new GUIContent ("Min Size", "Crosshair Min Size"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairMax"),
			new GUIContent ("Max Size", "Max Size"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairsAmount"),
			new GUIContent ("Size Amount", "Size Amount"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("crosshairSpeed"),
			new GUIContent ("Speed", "Crosshair Speed"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("crossHairRandomize"),
			new GUIContent ("Randomize", "Crosshair Randomize Size When Fire"), true);



		//----------------------------------------------------------------------------------


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Recoil And Shake", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;


		EditorGUILayout.PropertyField (serializedObject.FindProperty ("RecoilAmount"),
			new GUIContent ("Amount", "Recoil Amount"), true);
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("RecoilSpeed"),
			new GUIContent ("Speed", "Assign   Recoil Speed  "), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("reloadAnim"),
			new GUIContent ("Reload Animator", "Drag Reload Animator Here"), true);
		EditorGUILayout.Space ();

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("cameraShakeIntensity"),
			new GUIContent ("Shake Intensity", "Camera shake intensity"), true);
		EditorGUILayout.Space ();

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("cameraShakeDecay"),
			new GUIContent ("Shake Decay", "Camera Shake Decay"), true);
		EditorGUILayout.Space ();

		serializedObject.ApplyModifiedProperties ();
	}

}

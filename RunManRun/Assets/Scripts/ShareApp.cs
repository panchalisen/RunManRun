using UnityEngine;
using System.Collections;
 
 
public class ShareApp : MonoBehaviour {
  
 string subject = "Hungry Runner";
	//string body ="https://play.google.com/store/apps/details?id=com.Infocom.Teen_Patti";

	string link = "https://play.google.com/store/apps/details?id=com.US.Food.Rush";
	string desc =
		" Hungry? Do you want some rich dark chocolate? Or a yummy cheese burger? Or some delicious melt-in-the-mouth chocolate icecream? " +
		"You must try 'Hungry Runner 3D'. Hungry Runner is fun Running Game where you will find lots of such lip smacking items." +
		"Just run and grab them! Hungry Runner 3D- Download for free now!";
 
 public void shareText(){
 //execute the below lines if being run on a Android device
 #if UNITY_ANDROID
  //Refernece of AndroidJavaClass class for intent
  AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
  //Refernece of AndroidJavaObject class for intent
  AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
  //call setAction method of the Intent object created
  intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
  //set the type of sharing that is happening
  intentObject.Call<AndroidJavaObject>("setType", "text/plain");
  //add data to be passed to the other activity i.e., the data to be sent
  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), (link+desc));
  //get the current activity
  AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
  AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
  //start the activity by sending the intent data
  //----currentActivity.Call ("startActivity", intentObject);

		//https://forum.unity.com/threads/creating-a-share-button-intent-for-android-in-unity-that-forces-the-chooser.335751/
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);
 #endif
   
 }
  
}
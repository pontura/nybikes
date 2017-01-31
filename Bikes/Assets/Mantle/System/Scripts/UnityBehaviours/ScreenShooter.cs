using UnityEngine;
using System.Collections;
using MantleEngine.PluginComponents;


public class ScreenShooter : MonoBehaviour
{
	[Header("Press k to take screen shot")]

	public int resWidth = 2048;
	public int resHeight = 2048	;

	public enum ImageFormat{
		jpg,
		png
	}
	public ImageFormat imageFormat = ImageFormat.jpg;
	public TextureFormat textureFormat = TextureFormat.RGB24;

	private Camera cam = null;
	private bool disable = false;

	void Start()
	{
		cam = Camera.main;
		if (cam == null) 
			cam = FindObjectOfType<Camera>();
		if (cam == null)
		{
			Debug.LogWarning ("Screenshooter: Unable to find camera in screen!");
			disable = true;
		}
	}

	protected string ScreenShotName (int width, int height)
	{
		string desktopPath = System.Environment.GetFolderPath( System.Environment.SpecialFolder.Desktop );
		string sceneName = "unknown_area";
		if (Mantle.Instance != null) {sceneName = Mantle.Instance.Name;}

		return string.Format ("{0}/mantleshot_{1}_({2}x{3})_{4}." , 
			desktopPath, 
			sceneName,
			width, height, 
			System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss"))+ imageFormat.ToString();
	}

	protected void PlayCameraClickSound() {
		AudioClip ac = Resources.Load("camera_click") as AudioClip;
		if (ac != null) {
			AudioSource.PlayClipAtPoint(ac, this.transform.position,1);
		}
	}

	void LateUpdate ()
	{
		if (!disable && Input.GetKeyDown ("k")) 
		{
			RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
			cam.targetTexture = rt;
			Texture2D screenShot = new Texture2D (resWidth, resHeight, textureFormat, false);
			cam.Render ();
			RenderTexture.active = rt;
			screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
			cam.targetTexture = null;
			RenderTexture.active = null; 
			Destroy (rt);
			byte[] bytes;

			switch (imageFormat) {
			case ImageFormat.png:  
				bytes = screenShot.EncodeToPNG(); break;
			default:  
				bytes = screenShot.EncodeToJPG(100); break;
			}

			string filename = ScreenShotName (resWidth, resHeight);
			System.IO.File.WriteAllBytes (filename, bytes);
			PlayCameraClickSound();
			Debug.Log (string.Format ("Screenshot saved to : {0}", filename));
		}
	}

}
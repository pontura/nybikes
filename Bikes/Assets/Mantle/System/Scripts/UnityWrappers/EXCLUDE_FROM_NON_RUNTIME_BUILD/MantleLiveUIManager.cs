using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MantleEngine.PluginUtilities;
using MantleEngine.Mathematics;
using MantleEngine.Graphics;

using System.IO;
using MantleEngine.MapServices;
using MantleEngine.Utilities;
using UnityEngine.UI;



namespace MantleEngine.Runtime
{

	[System.Serializable]
	public class MantleLiveUIManager: MonoBehaviour {

		public Text textArea;
		public GameObject iconGPSStarting;
		public GameObject iconGPSRunning;
		public GameObject iconGPSFailed;
		public GameObject iconLoading;
		public GameObject iconLoadingFailed;



		void Awake() {

			HideAllIcons();
			SetupListeners();

		}


		private void SetupListeners() {
			
			RuntimeNotificationManager.Instance.LocationStatusUpdateE += ShowStatus_LocationServices;
				
			RuntimeNotificationManager.Instance.LoadingInProgressE += ShowStatus_LoadingInProgress;
			RuntimeNotificationManager.Instance.LoadingFailedE += ShowStatus_LoadingFailed;
			RuntimeNotificationManager.Instance.LoadingCompleteE += ShowStatus_LoadingComplete;
		


		}

		protected void HideAllIcons() {

			if (textArea != null) textArea.text = "";
			if (iconGPSStarting != null) iconGPSStarting.SetActive(false);
			if (iconGPSRunning != null) iconGPSRunning.SetActive(false);
			if (iconGPSFailed != null) iconGPSFailed.SetActive(false);
			if (iconLoading != null) iconLoading.SetActive(false);
			if (iconLoadingFailed != null) iconLoadingFailed.SetActive(false);

		}


		protected void ShowStatus_LocationServices(MantleLocationServices.LocationStatus status) {

			if (iconGPSStarting != null) iconGPSStarting.SetActive(status == MantleLocationServices.LocationStatus.Starting);
			if (iconGPSRunning != null) iconGPSRunning.SetActive(status == MantleLocationServices.LocationStatus.Running);
			if (iconGPSFailed != null) iconGPSFailed.SetActive(status == MantleLocationServices.LocationStatus.Failed);

		}



		protected void ShowStatus_LoadingComplete(string message = "") {

			if (iconLoading != null) {
				iconLoading.SetActive(false);
			}

			if (iconLoadingFailed != null) {
				iconLoadingFailed.SetActive(false);
			}
		}

		protected void ShowStatus_LoadingFailed(string message = "") {
			
			if (iconLoading != null) {
				iconLoading.SetActive(false);
			}

			if (iconLoadingFailed != null) {
				iconLoadingFailed.SetActive(true);
			}

			textArea.text = message;
		}


		protected void ShowStatus_LoadingInProgress(string message = "") {

			if (iconLoading != null) {
				iconLoading.SetActive(true);
			}

			if (iconLoadingFailed != null) {
				iconLoadingFailed.SetActive(false);
			}

		}







	}

}
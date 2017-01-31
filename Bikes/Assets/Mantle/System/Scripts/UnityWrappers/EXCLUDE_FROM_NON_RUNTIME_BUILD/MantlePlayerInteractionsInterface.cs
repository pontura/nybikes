
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace MantleEngine.Runtime 
{
	public class MantlePlayerInteractionsInterface : RuntimeMantleBehaviour
	{


		private MantlePlayerInteractions _script;

		void Start() {
			Instantiate();
				
		}

		public virtual MantlePlayerInteractions Instantiate() {

			_script = new MantlePlayerInteractions(); 
			SetVariables();
			MantleRuntimeManager.Instance.playerInteractions = _script;

			return _script;
		}


		protected virtual void SetVariables() {
			_script.audioSource = this.GetComponent<AudioSource>();
			if (_script.audioSource == null) {
				Debug.LogWarning("Warning: AudioSource not found on MantlePlayerInteractions gameobject " + this.gameObject.name);
			}
			_script.gameObject = this.gameObject;

		}

		void OnTriggerEnter(Collider other) {
			_script.OnTriggerEnter(other);
		}

		void OnTriggerExit(Collider other) {
			_script.OnTriggerExit(other);
		}

		public void PlayAudioClip(AudioClip clip) {
			_script.PlayAudioClip(clip);
		}


	}
}


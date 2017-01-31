using UnityEngine;
using System.Collections;
using MantleEngine.PluginComponents;
using MantleEngine.Mathematics;

namespace MantleEngine.Runtime 
{
	
	public class CollectableItemInterface : RuntimeMantleBehaviour {

		/// <summary>
		/// The collection sound. One sound is randomly selected and played on collection.
		/// </summary>
		public AudioClip[] collectionSounds = null;

		/// <summary>
		/// The collection objects. All gameObjects in this array are instantiated on collection.  This could include particle effects and children.
		/// </summary>
		public GameObject[] collectionObjects = null;


		protected CollectableItem _script = null;

		void Start() {
			Instantiate();
		}

		public virtual CollectableItem Instantiate() {

			_script = new CollectableItem();
			SetVariables();
			return _script;
		}


		protected virtual void SetVariables() {

			_script.parent = this.gameObject;

			_script.collectionSounds = collectionSounds;
			_script.collectionObjects = collectionObjects;


		}

		public override void RegisterCollisionEnter(MantlePlayerInteractions playerInteraction) {
			_script.DoCollection(playerInteraction, true);

		}

		public override void RegisterCollisionExit(MantlePlayerInteractions playerInteraction) {

		}

		public void  OnMouseDown() { 
			_script.DoCollection(MantleRuntimeManager.Instance.playerInteractions, true);
		}



	}

}

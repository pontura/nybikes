using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

using MantleEngine.PluginUtilities;

namespace MantleEngine.PluginComponents 
{
	[InitializeOnLoad]
	public static class MantleEditor_InitializeOnLoad
	{
		static MantleEditor_InitializeOnLoad()
		{
			DoOnLoadActions();

			Debug.Log("Mantle plugin ready.");
		}


		public static void DoOnLoadActions() {

			CreateLayers();

		}

		public static void CreateLayers() {
			
			Debug.Log("Mantle is ensuring that all dependent layers are present in the current project...");

			string[] requiredLayers = new string[]{ 
				Mantle.LAYERNAME_LANDUSE, 
				Mantle.LAYERNAME_EARTH, 
				Mantle.LAYERNAME_WATER, 
				Mantle.LAYERNAME_TRANSPORTNETWORK, 
				Mantle.LAYERNAME_BUILDING, 
				Mantle.LAYERNAME_VEHICLE
			};

			UnityLayerUtility.CheckLayers(requiredLayers);


		}
	}


}




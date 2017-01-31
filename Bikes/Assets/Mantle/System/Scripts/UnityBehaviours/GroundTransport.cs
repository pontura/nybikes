using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using MantleEngine.Mathematics;
using MantleEngine.PluginComponents;

namespace MantleEngine.Transport { 

	public class GroundTransport: Vehicle  {

		//These are hidden and should only be set via the VehicleInterface monobehaviour wrapper
		public bool useRandomBodyColor = true;
		public bool useRandomWheelColor = false;
		public bool useRandomScreenColor = false;
		public bool useRandomRimColor = false;

		public override void Init(Arc path, Node fromNode, Node toNode, MantleTransportNetwork.RoadFeatureKind[] traversableRoadTypes = null) {
			base.Init(path, fromNode, toNode, traversableRoadTypes);
			InitDriving();
			vehicleBehaviour = VehicleBehaviour.DRIVING;

			AnimatorPlay();
		}




		public override void Tick() {

			switch(vehicleBehaviour) {
			case VehicleBehaviour.DRIVING:
				DoDefaultMotion();
				break;
			default: //case VehicleBehaviour.STOPPED:

				break;
			}	
		}

		protected override void InitAppearance() {
			if (useRandomBodyColor || useRandomWheelColor || useRandomScreenColor) {
				//Renderer r = this.transform.GetComponentInChildren<Renderer>();
				Renderer[] rs = this.transform.GetComponentsInChildren<Renderer>();
				if (rs != null && TransSimManager.RNG != null){

					Color bCol = TransSimManager.RNG.RandomColor();
					Color sCol = TransSimManager.RNG.RandomColor();
					Color wCol = TransSimManager.RNG.RandomColor();
					Color rCol = TransSimManager.RNG.RandomColor();

					for (int ir = 0; ir < rs.Length; ir++) {
						Renderer r = rs[ir];

						//r.sharedMaterial.color = TransSimManager.RNG.RandomColor();
						for (int i = 0 ; i < r.materials.Length; i++) {
							//skip coloring certain car parts..
							string matName = r.materials[i].name.ToUpper();

							if (useRandomBodyColor && matName.Contains("BODY")) r.materials[i].color = bCol; 
							if (useRandomScreenColor && matName.Contains("SCREEN")) r.materials[i].color = sCol; 
							if (useRandomWheelColor && matName.Contains("WHEEL")) r.materials[i].color = wCol; 
							if (useRandomRimColor && matName.Contains("RIM")) r.materials[i].color = rCol; 

						}

					}
				}
			}
		}


	}
}
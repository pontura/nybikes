using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MantleEngine.PluginUtilities;
using MantleEngine.Mathematics;
using MantleEngine.Graphics;

using System.IO;



namespace MantleEngine.PluginComponents 
{

	[System.Serializable]
	public class MantleTerrainSubtypeInterface: System.Object {
		

		public string SubtypeName = ""; //DEFAULT_TERRAIN_SUB_TYPE + SUB_TERRAIN_PROPERTY_EXTENTION ;
		[HideInInspector]
		public int _subtypeNameDropdownIndex = 0;

		public MantleStyleInterface style;

		public bool Include = true; //change to OverrideBasicTerrain

		[HideInInspector]
		public int subtypeOrder = -1;

		[HideInInspector]
		public string[] validKnownTerrainTypes = null; //to be populated in a static constructor of a child class.

		public virtual MantleTerrainSubtypeInterface ShallowCopy()
		{
			MantleTerrainSubtypeInterface mtsi = new MantleTerrainSubtypeInterface ();
			ShallowCopyInto (mtsi);
			return mtsi;
		}

		protected void ShallowCopyInto(MantleTerrainSubtypeInterface mtsi)
		{
			mtsi.SubtypeName = SubtypeName;
			mtsi._subtypeNameDropdownIndex = _subtypeNameDropdownIndex;
			mtsi.style = style;
			mtsi.Include = Include;
			mtsi.subtypeOrder = subtypeOrder;
			mtsi.validKnownTerrainTypes = validKnownTerrainTypes;
		}


		protected MantleTerrainSubtype _script = null;

		public virtual MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype();
			SetVariables();
			return _script;
		}


		protected virtual void SetVariables() {

			_script.SubtypeName = SubtypeName;
			if (style != null) _script.style = style.Instantiate();
			_script.Include = Include; //change to OverrideBasicTerrain

		}





	}

}
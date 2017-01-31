using UnityEngine;
using System.Collections;

using MantleEngine.Graphics;

namespace MantleEngine.PluginComponents 
{



	[System.Serializable]
	public class MantleStyleInterface: ScriptableObject {

		//public string StyleName = "NewMantleStyle";

		[Header("Material Settings")]

		public MantleMaterial[] TopMaterial;
		public UVNinja.UVMethodPolyPlane topUvMethod = UVNinja.UVMethodPolyPlane.TileBased;

		public bool includeSides = false;

		public MantleMaterial[] SideMaterial;
		public UVNinja.UVMethodQuad sideUvMethod = UVNinja.UVMethodQuad.QuadTileBased;

		public float minSideHeight = MantleStyle.AUTO_SIDE_HEIGHT;
		public float maxSideHeight = MantleStyle.AUTO_SIDE_HEIGHT;

		public MantleStyle.ImageOverlayMethod imageOverlayMethod = MantleStyle.ImageOverlayMethod.BlendWithStyle;

		[Header("Terrain Placement Settings")]
		public bool bypassSmallAreas = false;
		public float minAreaToFillSqrMeters = 0f; // this is a rought directive compared against bounds size.
		public MantleTerrainFillAsset[] TerrainFill ;
		public MantleTerrainEdgeAsset[] TerrainEdge  ;

		protected MantleStyle _script = null;
		protected static MantleStyleInterface _systemDefault= null;


		public virtual MantleStyleInterface ShallowCopy()
		{
			MantleStyleInterface msi = ScriptableObject.CreateInstance<MantleStyleInterface>();
			ShallowCopyInto (msi);
			return msi;
		}

		protected virtual void ShallowCopyInto(MantleStyleInterface msi)
		{
			msi.name = name;
			msi.TopMaterial = TopMaterial;
			msi.topUvMethod = topUvMethod;
			msi.includeSides = includeSides;
			msi.SideMaterial = SideMaterial;
			msi.sideUvMethod = sideUvMethod;
			msi.minSideHeight = minSideHeight;
			msi.maxSideHeight = maxSideHeight;
			msi.imageOverlayMethod = imageOverlayMethod;
			msi.bypassSmallAreas = bypassSmallAreas;
			msi.minAreaToFillSqrMeters = minAreaToFillSqrMeters;
			msi.TerrainFill = TerrainFill;
			msi._script = _script.ShallowCopy();

		}

		public virtual MantleStyle Instantiate() {
			
			_script = new MantleStyle();
			SetVariables();
			return _script;
		}

		public virtual void LoadDefaults() {


		}


		protected virtual void SetVariables() {

			_script.name = this.name;
			_script.TopMaterial = TopMaterial; // new
			_script.topUvMethod = topUvMethod;
			_script.includeSides = includeSides;
			_script.SideMaterial = SideMaterial; //new
			_script.sideUvMethod = sideUvMethod;
			_script.minSideHeight = minSideHeight;
			_script.maxSideHeight = maxSideHeight;
			_script.imageOverlayMethod = imageOverlayMethod;
			_script.bypassSmallAreas = bypassSmallAreas;
			_script.minAreaToFillSqrMeters = minAreaToFillSqrMeters;
			_script.TerrainFill = TerrainFill;
			_script.TerrainEdging  = TerrainEdge;

		}

		[ExecuteInEditMode]
		protected virtual void OnValidate() {

			MantleTerrainAsset.ValidateTerrainAssets(TerrainFill);
			MantleTerrainAsset.ValidateTerrainAssets(TerrainEdge);




		}

		public virtual void CopyFrom(MantleStyleInterface fromStyle) 
		{
			fromStyle.ShallowCopyInto(this);
		}



		public static MantleStyleInterface GetSystemDefault() {

			if (_systemDefault== null) {
				ScriptableObject obj = Resources.Load(Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_NAME) as ScriptableObject;

				if (obj == null) {
					Mantle.Instance.PrintMessage("Missing resource file '"+Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_NAME+"'!", ConsoleMessageType.Error);
					return null;
				}
				_systemDefault  = (MantleStyleInterface)obj;
			}

			return _systemDefault;


		}
		public static MantleStyle GetSystemDefaultStyle() {
			
			MantleStyle ms = null;

			if (GetSystemDefault() != null) {
				ms = _systemDefault.Instantiate();
			}

			return ms;

		}



	}

}
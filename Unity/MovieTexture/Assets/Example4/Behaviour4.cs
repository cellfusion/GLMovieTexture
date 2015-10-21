using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Behaviour4 : MonoBehaviour {
	
	public RawImage _rawImage;
	GLMovieTextureObject _mto;
	
	void Start(){
		LoadMovieTexture("Movie2.m4v");
	}
	
	void OnDestroy(){
		if( _mto != null ){
			Destroy(_mto);
		}
	}
	
	void LoadMovieTexture(string moviePath){
		if( _rawImage == null || moviePath == null ){ return; }
		if( _mto != null ){
			Destroy(_mto);
			_mto = null;	
		}
		
		Texture2D texture = new Texture2D(1,1,TextureFormat.ARGB32, false);
		_mto = ScriptableObject.CreateInstance<GLMovieTextureObject>();
		_mto.Load(texture, moviePath);
		_mto.SetLoop(true);
		_mto.Play();
		
		_rawImage.texture = texture;
	}
}

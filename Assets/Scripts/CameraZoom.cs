using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	//public Transform target;
	public float zoom = 5;
	public float zoomSpeed = 1;

	private bool isZooming = false;
	private float zoomTo;
	private float[] zoomLevels = {1,2,5,8,10};
	private int zoomIndex = 0;

	void Start() {
		this.camera.orthographicSize = zoom;
		if (zoomSpeed < 0) zoomSpeed = 1;
	}
	
	void Update () {
		if (isZooming) {
			zoom = Mathf.Lerp(zoom,zoomTo,Time.deltaTime*zoomSpeed);
			if (Mathf.Abs(zoomTo-zoom) < 0.05) {
				zoom = zoomTo;
				isZooming = false;
			}
			this.camera.orthographicSize = zoom;
		}
	}

	public void SetZoom(float newZoom) {
		if (newZoom < 1)
			newZoom = 1;
		if (newZoom > 10)
			newZoom = 10;
		isZooming = true;
		zoomTo = newZoom;
	}

	private void DetermineZoomIndex() {
		zoomIndex = 0;
		foreach (float lvl in zoomLevels) {
			if (lvl == 10)
				break;
			if (zoomTo > lvl)
				zoomIndex++;
		}
	}

	public void ZoomIn() {
		DetermineZoomIndex();
		if (zoomIndex > 0)
			zoomIndex--;
		SetZoom(zoomLevels[zoomIndex]);
	}

	public void ZoomOut() {
		DetermineZoomIndex();
		if (zoomIndex < 4)
			zoomIndex++;
		SetZoom(zoomLevels[zoomIndex]);
	}

	public void SetZoomSpeed(float newSpeed) {
		zoomSpeed = newSpeed;
	}
}

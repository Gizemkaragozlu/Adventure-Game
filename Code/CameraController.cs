// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraWork.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in PUN Basics Tutorial to deal with the Camera work to follow the player
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Photon.Pun.Demo.PunBasics
{
	/// <summary>
	/// Camera work. Follow a target
	/// </summary>
	public class CameraController : MonoBehaviour
	{

		private Transform target;
		public  PhotonView view;
        public Vector3 offset = new Vector3(0,0,-15);

		public void Update(){
			if(view.IsMine){
            	this.transform.position = view.transform.position+ offset;
			}
			
		}
    
		
	}
}
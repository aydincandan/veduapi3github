using SehirRehberi.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SehirRehberi.API.Data
{
	public class MyRestResponse
	{
		HttpResponseMessage _HRM;
		readonly MyResponseObject _MRO;
		Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary _myModelState;
		object _MyRequestObject;
		string _Description;

		public MyRestResponse(
			System.Net.HttpStatusCode httpStatusCode, 
			Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary myModelState,
			dynamic myrequestObject
			,string myrequestObjectNAME
			)
		{
			this._HRM = new HttpResponseMessage(httpStatusCode);
			this._MRO = new MyResponseObject(_HRM);
			this._myModelState = myModelState;
			this._MyRequestObject = myrequestObject;
			this.MyRequestObjectLocalName = _ControllersHelper.MemberInfoGetting.GetMemberName(() => myrequestObject);// maalesef doğası gereği böyle olamıyor
			this.MyRequestObjectLocalName = myrequestObjectNAME; // ok
		}

		public string MyRequestObjecttypeofName { get => this._MyRequestObject.GetType().FullName; }
		public string MyRequestObjectLocalName  { get; }
		public string Description
		{
			get => _Description;
			set => _Description = value;
		}

		public object ModelStateAddedErrors{ get => this._myModelState.Values.SelectMany(x => x.Errors); }

		public object MyRequestObject { get => this._MyRequestObject; }

		public MyResponseObject MyResponseObject { get => this._MRO; }
	}

	public class MyResponseObject
	{
		public MyResponseObject(HttpResponseMessage HRM) { this._HRM = HRM; }

		#region _HRM
		public HttpContent Content { get { return this._HRM.Content; } }
		public int StatusCode { get { return (int)this._HRM.StatusCode; } }
		//public string HttpStatus { get { return this._HRM.StatusCode.ToString(); } }
		public string ReasonPhrase { get { return this._HRM.ReasonPhrase; } }
		public System.Net.Http.Headers.HttpResponseHeaders Headers { get { return this._HRM.Headers; } }
		public HttpRequestMessage RequestMessage { get { return this._HRM.RequestMessage; } }
		public bool IsSuccessStatusCode { get => this._HRM.IsSuccessStatusCode; }
		#endregion

		HttpResponseMessage _HRM { get; set; } // public yaparsan tüm bu obje Postman den gözükür. 
	}
}

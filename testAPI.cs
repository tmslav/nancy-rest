using System;
using Nancy;
using testAPI.data;
using System.Web.Script.Serialization;
using Nancy.Extensions;

namespace testAPI.Models
{
	public class testAPI:NancyModule
	{
		private static Data data = new Data();
		public testAPI ()
		{
			Get["/"] = _ => "REST Server";

			//POSTS
			Get ["/posts/{id}"] = p => {
				return new JavaScriptSerializer().Serialize(data.GetPostById(p.id));
			};

			Post ["/posts/new/"] = p => {
				DataPost dp = new JavaScriptSerializer().Deserialize<DataPost>(this.Request.Body.AsString());
				data.InsertPost(dp.post_id,dp.post_body,dp.post_user);
				return Response.AsRedirect("/posts/"+dp.post_id.ToString(),Nancy.Responses.RedirectResponse.RedirectType.SeeOther);
			};

			Delete ["/posts/delete/{id}"] = p => {
				return data.RemovePost (p.id);
			};

			Get["/posts/list"] = _=>{
				return new JavaScriptSerializer().Serialize(data.posts);
			};


			//USERS
			Get ["/users/{id}"] = p => {
				return new JavaScriptSerializer().Serialize(data.GetPostById(p.id));
			};

			Post ["/users/new/"] = p => {
				DataUser dp = new JavaScriptSerializer().Deserialize<DataUser>(this.Request.Body.AsString());
				data.InsertUser(dp.user_id,dp.user_name,dp.user_password);
				return Response.AsRedirect("/users/"+dp.user_id.ToString(),Nancy.Responses.RedirectResponse.RedirectType.SeeOther);
			};
			Delete["/users/delete/{id}"] = p =>{
				return data.RemoveUser(p.id);
			};

			Get ["/users/list"] = p => {
				return new JavaScriptSerializer ().Serialize (data.users);

			};
		}
	}
}

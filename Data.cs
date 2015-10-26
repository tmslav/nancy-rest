using System;
using System.Collections.Generic;

namespace testAPI.data
{
	public class Data{
		public List<DataUser> users = new List<DataUser>();
		public List<DataPost>posts = new List<DataPost>();

		public void InsertUser(int user_id,string user_name,string user_password){
			users.Insert (0, new DataUser{ user_id=user_id, user_name=user_name, user_password=user_password });
		}

		public DataUser GetUserById(int id){
			foreach (DataUser u in users)
				if (u.user_id == id)
					return u;
			return null;
		}
				
		public bool RemoveUser(int user_id){
			DataUser u = GetUserById (user_id);
			if (u != null) {
				users.Remove (u);
				return true;
			}
			return false;
			
		}

		public void InsertPost(int post_id,string post_body,string post_user){
			if (posts.Count > post_id)
				posts.Insert (post_id, new DataPost{ post_id = post_id, post_body = post_body, post_user = post_user });
			else {
				posts.Insert (0, new DataPost{ post_id = post_id, post_body = post_body, post_user = post_user });
			}
		}

		public DataPost GetPostById(int id){
			foreach (DataPost p in posts)
				if (p.post_id == id)
					return p;
			return null;
		}

		public bool RemovePost(int post_id){
			DataPost p = GetPostById (post_id);
			if (p != null) {
				posts.Remove (p);
				return true;
			}
			return false;
		}
	}

	public class DataUser
	{
		public int user_id{ get; set; }
		public string user_name{ get; set; }
		public string user_password{ get; set; }
	}

	public class DataPost{
		public int post_id{ get; set; }
		public string post_body{ get; set; }
		public string post_user{ get; set; }
	}
}


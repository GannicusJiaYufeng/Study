/**  版本信息模板在安装目录下，可自行修改。
* AdminUsers.cs
*
* 功 能： N/A
* 类 名： AdminUsers
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/16 9:36:57   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace KH.Model
{
	/// <summary>
	/// AdminUsers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AdminUsers
	{
		public AdminUsers()
		{}
		#region Model
		private long _id;
		private string _username;
		private string _password;
		private bool _isenabled;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// md5
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// shifoujinyong
		/// </summary>
		public bool IsEnabled
		{
			set{ _isenabled=value;}
			get{return _isenabled;}
		}
		#endregion Model

	}
}


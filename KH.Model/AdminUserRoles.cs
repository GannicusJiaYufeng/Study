/**  版本信息模板在安装目录下，可自行修改。
* AdminUserRoles.cs
*
* 功 能： N/A
* 类 名： AdminUserRoles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/21 10:48:40   N/A    初版
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
	/// AdminUserRoles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AdminUserRoles
	{
		public AdminUserRoles()
		{}
		#region Model
		private long _id;
		private long _adminuserid;
		private long _roleid;
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
		public long AdminUserId
		{
			set{ _adminuserid=value;}
			get{return _adminuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}


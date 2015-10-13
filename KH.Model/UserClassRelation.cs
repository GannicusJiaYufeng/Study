/**  版本信息模板在安装目录下，可自行修改。
* UserClassRelation.cs
*
* 功 能： N/A
* 类 名： UserClassRelation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/10 18:45:51   N/A    初版
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
	/// UserClassRelation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserClassRelation
	{
		public UserClassRelation()
		{}
		#region Model
		private long _id;
		private long _studentid;
		private long _classid;
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
		public long StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		#endregion Model

	}
}


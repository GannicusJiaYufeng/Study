/**  版本信息模板在安装目录下，可自行修改。
* UserActiveCodes.cs
*
* 功 能： N/A
* 类 名： UserActiveCodes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/4 18:57:04   N/A    初版
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
	/// UserActiveCodes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserActiveCodes
	{
		public UserActiveCodes()
		{}
		#region Model
		private long _id;
		private string _username;
		private string _activecode;
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
		/// 
		/// </summary>
		public string ActiveCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		#endregion Model

	}
}


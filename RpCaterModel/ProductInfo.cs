using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class ProductInfo
    {
        //ProId, CId, ProName, ProCost, ProSpell, ProPrice, ProUnit, Remark, DelFlag, SubTime, ProStock, ProNum, SubBy

        private int _proId;

        public int ProId
        {
            get { return _proId; }
            set { _proId = value; }
        }
       private int _cId;

       public int CId
       {
           get { return _cId; }
           set { _cId = value; }
       }
       private string _proName;

       public string ProName
       {
           get { return _proName; }
           set { _proName = value; }
       }
       private double _proCost;

       public double ProCost
       {
           get { return _proCost; }
           set { _proCost = value; }
       }
       private string _proSpell;

       public string ProSpell
       {
           get { return _proSpell; }
           set { _proSpell = value; }
       }
       private double _proPrice;

       public double ProPrice
       {
           get { return _proPrice; }
           set { _proPrice = value; }
       }
       private string _proUnit;

       public string ProUnit
       {
           get { return _proUnit; }
           set { _proUnit = value; }
       }
       private string _remark;

       public string Remark
       {
           get { return _remark; }
           set { _remark = value; }
       }
       private int _delFlag;

       public int DelFlag
       {
           get { return _delFlag; }
           set { _delFlag = value; }
       }
       private DateTime _subTime;

       public DateTime SubTime
       {
           get { return _subTime; }
           set { _subTime = value; }
       }
       private int _proStock;

       public int ProStock
       {
           get { return _proStock; }
           set { _proStock = value; }
       }
       private string _proNum;

       public string ProNum
       {
           get { return _proNum; }
           set { _proNum = value; }
       }
       private int _subBy;

       public int SubBy
       {
           get { return _subBy; }
           set { _subBy = value; }
       }
    }
}

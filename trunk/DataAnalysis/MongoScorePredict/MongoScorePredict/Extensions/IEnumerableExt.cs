using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace MongoScorePredict.Extensions
{
    public static class IEnumerableExt
    {

        /// <summary>
        /// 转换为一个DataTable,用字段还是属性，很关键，否则不能转，getfield,getproperty
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<TResult>(this IEnumerable<TResult> value) where TResult : class
        {
            //创建属性的集合
            List<FieldInfo> pList = new List<FieldInfo>();
            //获得反射的入口
            Type type = typeof(TResult);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            //Array.ForEach<FieldInfo>(type.GetFields(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.FieldType); });
            foreach (var p in type.GetFields())
            {
                pList.Add(p);
                dt.Columns.Add(p.Name, p.FieldType);
            }
            foreach (var item in value)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
    }

}

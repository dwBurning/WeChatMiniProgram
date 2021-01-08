using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReallyWantToApi.Models
{
    /// <summary>
    /// 通用结果返回类型
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// 返回码 0 表示成功 其余表示失败
        /// </summary>
        public ResponseResult Code { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string Message { get { return this.Code.ToString(); } }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Context { get; set; }
    }

    /// <summary>
    /// 通用结果枚举类型
    /// </summary>
    public enum ResponseResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success,

        /// <summary>
        /// 失败
        /// </summary>
        Falied,

        /// <summary>
        /// 错误
        /// </summary>
        Error
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReallyWantToApi.Models
{
    public class Contact
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }
}
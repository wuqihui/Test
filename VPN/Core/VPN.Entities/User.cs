using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VPN.Core.Entities
{
    /// <summary>
    /// 用户模型
    /// <remarks>
    /// 创建：2014.02.02<br />
    /// 修改：2014.02.05
    /// </remarks>
    /// </summary>
    public class User:EntityBase<int>
    {

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "用户名")]
        public virtual string UserName { get; set; }

        /// <summary>
        /// 用户组ID
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "用户组ID")]
        public virtual int GroupID { get; set; }
        public virtual EntityEnums.Sex Sex { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        /// <summary>
        /// 用户状态<br />
        /// 0正常，1锁定，2未通过邮件验证，3未通过管理员
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public virtual DateTime LoginTime { get; set; }

        /// <summary>
        /// 上次登陆IP
        /// </summary>
        public virtual String LoginIP { get; set; }

        public virtual UserGroup Group { get; set; }
        /// <summary>
        /// 订阅订单
        /// </summary>
        public virtual IList<Order> Orders { get; set; }
    }
}

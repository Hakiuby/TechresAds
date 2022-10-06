﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techres_Marketing.Helper;
using Techres_Marketing.Models.Response;

namespace Techres_Marketing.Models.Request
{
    public class LoginNodeWrapper
    {
        [JsonProperty(PropertyName = "type_user")]
        public int TypeUser { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public long UserId { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "os_name")]
        public string OsName { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public int Gender { get; set; }
        [JsonProperty(PropertyName = "restaurant_id")]
        public long RestaurantId { get; set; }
        [JsonProperty(PropertyName = "branch_id")]
        public long BranchId { get; set; }
        [JsonProperty(PropertyName = "employee_role_name")]
        public string EmployeeRoleName { get; set; }
        [JsonProperty(PropertyName = "device_name")]
        public string DeviceName { get; set; }
        [JsonProperty(PropertyName = "device_uid")]
        public string DeviceUid { get; set; }

        [JsonProperty(PropertyName = "role_id")]
        public long RoleId { get; set; }

        public LoginNodeWrapper(UserResponse user, string password)
        {
            this.TypeUser = 2;
            this.UserName = user.Data.Username;
            this.UserId = user.Data.Id;
            this.FullName = user.Data.Name;
            this.Password = Utils.Base64Encode(password);
            this.OsName = "windows";
            this.Phone = user.Data.Phone;
            this.Avatar = user.Data.Avatar;
            //this.Gender = user.g
            this.RestaurantId = user.Data.RestaurantId;
            this.BranchId = user.Data.BranchId;
            this.EmployeeRoleName = user.Data.EmployeeRoleName;
            this.DeviceName = "";
            this.DeviceUid = "";
            this.RoleId = user.Data.EmployeeRoleId;
        }
    }
}

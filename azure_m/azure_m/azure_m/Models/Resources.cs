﻿using System;


namespace azure_m.Models
{


    //public class BaseAzureItem
    //{
    //    public string Name { get; set; }
    //    public string Id { get; set; }
    //    public object Properties { get; set; }
    //}


    /// <summary>
    /// 用于所有资源列表
    /// </summary>
    /// <typeparam name="T">虚拟资源，对应虚拟资源类型</typeparam>
    public class Resources
    {
        public string ChangeTime { get; set; }
        public string CreatedTime { get; set; }
        public string Kind { get; set; }
        public string Location { get; set; }
        public string ManagedBy { get; set; }
        //public object Properties { get; set; }
        //public string provisioningState { get; set; }
    }
}
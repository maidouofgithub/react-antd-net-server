﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ReactAntdServer.Api.Enums;

namespace ReactAntdServer.Api.Attributes
{
    /// <summary>
    /// 自定义路由 /api/{version}/[controler]/[action]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
    {

        /// <summary>
        /// 分组名称,是来实现接口 IApiDescriptionGroupNameProvider
        /// </summary>
        public string GroupName { get; set; }

        //控制器基类 路由
        public CustomRouteAttribute() : base($"/api/[controller]")
        {
            
        } 

        /// <summary>
        /// 自定义路由构造函数，继承基类路由
        /// </summary>
        /// <param name="version"></param>
        public CustomRouteAttribute(ApiVersions version) : base($"/api/{version}/[controller]")
        {
        }

        public CustomRouteAttribute(ApiVersions version, string pathName) : base($"/api/{version}/{pathName}/[controller]")
        {

        }

        /// <summary>
        /// 自定义版本+路由构造函数，继承基类路由
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="version"></param>
        /// <param name="controller"></param>
        //public CustomRouteAttribute(ApiVersions version, string controller, string actionName = "[action]") : base($"/api/{version}/{controller}/{actionName}")
        //{
        //    GroupName = version.ToString();
        //}
    }
}

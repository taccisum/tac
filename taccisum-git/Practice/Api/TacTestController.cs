using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Practice.ViewModels;

namespace Practice.Api
{
    /// <summary>
    /// Tac Test Controller
    /// </summary>
    public class TacTestController : ApiController
    {
        /// <summary>
        /// 返回一个hi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Hello()
        {
            return "hi";
        }

        [HttpPost]
        public TestModel TestPost(TestModel model)
        {
            if (ModelState.IsValid)
            {
                return model;
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Practice.ViewModels;

namespace Practice.Api
{
    public class TacTest1Controller : ApiController
    {

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
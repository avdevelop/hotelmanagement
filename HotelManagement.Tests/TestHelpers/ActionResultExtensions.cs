using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelManagement.Tests.TestHelpers
{
    public static class ActionResultExtensions
    {
        public static TViewData AssertAreSame<TViewData, TProperty>(
            this TViewData viewData,
            TProperty expected,
            Func<TViewData, TProperty> property)
            where TProperty : class
        {
            if (expected != property(viewData))
            {
                throw new Exception(String.Format("Not same, expected {0}, actual {1}", expected, property(viewData)));
            }
            return viewData;
        }

        public static ViewResult ReturnsViewResult(this ActionResult result)
        {
            var viewResult = result as ViewResult;
            if (viewResult == null)
            {
                throw new Exception("result is not a ViewResult");
            }
            return viewResult;
        }

        public static RedirectToRouteResult ReturnsRedirectToRouteResult(this ActionResult result)
        {
            var viewResult = result as RedirectToRouteResult;
            if (viewResult == null)
            {
                throw new Exception("result is not a RedirectToRouteResult");
            }
            return viewResult;
        }

        public static T WithModel<T>(this ViewResult viewResult) where T : class
        {
            var model = viewResult.ViewData.Model as T;
            if (model == null)
            {
                throw new Exception(String.Format("model is not an instance of {0}", typeof(T).Name));
            }
            return model;
        }

        public static void IsNotNull(this object obj)
        {
            Assert.IsNotNull(obj);
        }
    }
}

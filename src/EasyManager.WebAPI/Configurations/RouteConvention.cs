using System.Linq;
using EasyManager.WebAPI.Attributes;
using EasyManager.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EasyManager.WebAPI.Configurations
{
    /// <summary>
    /// Sets the rout convertion
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _centralPrefix;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="routeTemplateProvider"></param>
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }
        
        /// <summary>
        /// Applies the configuration
        /// </summary>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                var versionSelector = controller.Attributes.Where(x=> x.GetType() == typeof(VersionAttribute));

                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        if(versionSelector.Any())
                        {
                            var v = (VersionAttribute)versionSelector.First();
                            _centralPrefix.Template = _centralPrefix.Template.Replace("{version}", v.Version);
                            selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
                            selectorModel.AttributeRouteModel);
                        }
                        else
                            selectorModel.AttributeRouteModel = null;
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();

                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
    }

    /// <summary>
    /// MVC options extension
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <summary>
        /// Uses central route prefix
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="routeAttribute"></param>
        public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }
    }
}
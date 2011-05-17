namespace SchoolRegister.Web.Infrastructure
{
    using System;
    using System.Globalization;
    using System.Web.Mvc;

    public class CurrentPanelValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext ctx)
        {
            return new CurrentTimeValueProvider(ctx.ParentActionViewContext);
        }

        private class CurrentTimeValueProvider : IValueProvider
        {
            private readonly ControllerContext parentContext;

            public CurrentTimeValueProvider(ControllerContext parentActionControllerContext)
            {
                this.parentContext = parentActionControllerContext;
            }

            public bool ContainsPrefix(string prefix)
            {
                return prefix.Equals("currentPanel", StringComparison.OrdinalIgnoreCase);
            }

            public ValueProviderResult GetValue(string key)
            {
                if (this.ContainsPrefix(key) && this.parentContext != null)
                {
                    string panelName = (string)this.parentContext.RouteData.Values["controller"];
                    return new ValueProviderResult(panelName, null, CultureInfo.CurrentCulture);
                }
                return null;

            }
        }
    }
}
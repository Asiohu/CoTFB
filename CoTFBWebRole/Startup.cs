using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoTFBWebRole.Startup))]
namespace CoTFBWebRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}

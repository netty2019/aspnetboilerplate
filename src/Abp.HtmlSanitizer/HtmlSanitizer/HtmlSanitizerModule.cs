﻿using System.Reflection;
using Abp.Dependency;
using Abp.HtmlSanitizer.HtmlSanitizer.Interceptor;
using Abp.Modules;
using Ganss.Xss;

namespace Abp.HtmlSanitizer.HtmlSanitizer;

[DependsOn(typeof(AbpKernelModule))]    
public class HtmlSanitizerModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        
        HtmlSanitizerInterceptorRegistrar.Initialize(IocManager);
        
        IocManager.Register<IHtmlSanitizer, Ganss.Xss.HtmlSanitizer>(DependencyLifeStyle.Transient);
    }
}
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nansen.Components.TinyMCETemplates.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class TemplateInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            var customTemplateStyling = ConfigurationManager.AppSettings["nansen:tinymce:customcss"];
            var useCustomTemplateStyling = false;
            bool.TryParse(customTemplateStyling, out useCustomTemplateStyling);

            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                var subFolder = useCustomTemplateStyling ? "custom" : "bootstrap";
                var templatePath = $"{EPiServer.Shell.Paths.ProtectedRootPath}Nansen.TinyMCETemplates/templates/{subFolder}";
                config.Default()
                    .AddSetting("templates", new[]
                    {
                        new {title= "Article Template: 2 Image Columns", url=$"{templatePath}/article_template_1.html", description="Template w/Side by side Images"},
                        new {title= "Article Template: 3 Image Columns", url=$"{templatePath}/article_template_2.html", description="Template with three image colums"},
                        new {title= "Image Layout: 2 Columns", url=$"{templatePath}/image_template_2_col.html", description="Template with two images"},
                        new {title= "Image Layout: 3 Columns", url=$"{templatePath}/image_template_3_col.html", description="Template with three images"},
                        new {title= "Image Layout with Caption: 1 Column", url=$"{templatePath}/image_template_caption.html", description="Template with single column image and caption"},
                        new {title= "Image Layout with Caption: 2 Columns", url=$"{templatePath}/image_template_caption_2.html", description="Template with two columns: image and caption"},
                        new {title= "Image Layout with Caption: 3 Columns", url=$"{templatePath}/image_template_caption_3.html", description="Template with three columns image and caption"},
                        new {title= "General: 2 Column Layout: (50%/50%)", url=$"{templatePath}/two_columns.html", description="Template with two columns"},
                        new {title= "General: 2 Column Layout: Image Left / Text Right (33%/66%) - 1 Row", url=$"{templatePath}/two_columns_image_left.html", description="Template with two columns. Image on the left."},
                        new {title= "General: 2 Column Layout: Text Left / Image Right (66%/33%) - 1 Row", url=$"{templatePath}/two_columns_image_right.html", description="Template with two columns. Image on the right."},
                        new {title= "General: 3 Column Layout", url=$"{templatePath}/three_columns.html", description="Template with three columns"},
                        new {title= "Accordion", url=$"{templatePath}/accordion.html", description="Single accordion template prefilled with some terms and conditions"},

                    })
                    .AddPlugin($"{DefaultValues.EpiserverPlugins} template")
                    .Toolbar($"{DefaultValues.Toolbar} | template");
            });
        }

        public void Initialize(InitializationEngine context)
        {

        }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }
}

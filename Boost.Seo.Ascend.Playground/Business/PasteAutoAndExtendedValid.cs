using EPiServer.Editor.TinyMCE;

namespace Boost.Seo.Ascend.Playground.Business
{
    [TinyMCEPluginNonVisual(
            AlwaysEnabled = true,
            PlugInName = "PasteAutoAndExtendedValid",
            DisplayName = "Paste auto cleanup & extended valid elements",
            Description = "Paste auto cleanup & extended valid elements",
            EditorInitConfigurationOptions =
            @"{
                paste_text_sticky : true,
                paste_text_sticky_default: true,
                paste_auto_cleanup_on_paste : true,
                paste_strip_class_attributes: 'all',
                formats: {
                    removeformat : 
                    [
                        {selector : 'b,strong,em,i,font,u,strike,h1,h2,h3,h4,h5,h6', remove : 'all', split : true, expand : false, block_expand : true, deep : true},
                        {selector : 'span', attributes : ['style', 'class'], remove : 'empty', split : true, expand : false, deep : true},
                        {selector : '*', attributes : ['style', 'class'], split : false, expand : false, deep : true}
                    ]
                },
                extended_valid_elements: 'iframe[src|frameborder|allowfullscreen|webkitallowfullscreen|mozallowfullscreen|width|height|class]'
            }"
    )]
    public class PasteAutoAndExtendedValid
    {
    }
}
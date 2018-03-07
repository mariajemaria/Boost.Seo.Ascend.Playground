namespace Boost.Seo.Ascend.Playground.Models.ViewModels
{
    public class RelMetaModel
    {
        public string RelPrev { get; set; }
        public string RelNext { get; set; }
        public bool ShowRelPrev => !string.IsNullOrEmpty(RelPrev);
        public bool ShowRelNext => !string.IsNullOrEmpty(RelNext);
    }
}
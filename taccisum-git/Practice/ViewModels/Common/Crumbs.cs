using System.Collections.Generic;

namespace Practice.ViewModels.Common
{
    public class Crumbs
    {
        public Crumbs(List<CrumbPath> paths, string icon = "icon-home")
        {
            Icon = icon;
            Paths = paths;
        }

        public string Icon { get; set; }
        public List<CrumbPath> Paths { get; set; }
    }

    public class CrumbPath
    {
        public CrumbPath(string name, string href)
        {
            Name = name;
            Href = href;
            IsLink = true;
        }

        public CrumbPath(string name)
        {
            Name = name;
            Href = "javascript:void(0)";
            IsLink = false;
        }

        public string Name { get; set; }
        public bool IsLink { get; set; }
        public string Href { get; set; }
    }
}
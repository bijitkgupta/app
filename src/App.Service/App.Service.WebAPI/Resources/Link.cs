using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Service.WebAPI.Resources
{
    public abstract class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }

        protected Link(string rel, string href, string title)
        {
            Rel = rel;
            Href = href;
            Title = title;
        }
    }

    public class EditLink : Link
    {
        public EditLink(string href, string title = null) : base("edit", href, title) { }
    }

    public class SelfLink : Link
    {
        public SelfLink(string href, string title = null) : base("self", href, title) { }
    }

    public class FirstLink : Link
    {
        public FirstLink(string href, string title = null) : base("first", href, title) { }
    }

    public class LastLink : Link
    {
        public LastLink(string href, string title = null) : base("last", href, title) { }
    }

    public class NextLink : Link
    {
        public NextLink(string href, string title = null) : base("next", href, title) { }
    }

    public class PreviousLink : Link
    {
        public PreviousLink(string href, string title = null) : base("prev", href, title) { }
    }
}

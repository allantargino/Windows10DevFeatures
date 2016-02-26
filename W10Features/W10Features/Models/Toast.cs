using System.Collections.Generic;

namespace W10Features.Models
{
    public class Toast
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string ImgAlt { get; set; }
        public Dictionary<int,string> Selections { get; set; }
        public Dictionary<string,string> Actions { get; set; }

        public Toast()
        {
            Title = "Title goes here";
            Content = "Content goes here";
            Image = "ms-appx:///assets/cartoon-sun.gif";
            ImgAlt = "Image text alternative";

            Selections = new Dictionary<int, string>();
            Selections.Add(1, "Breakfast");
            Selections.Add(2, "Lunch");
            Selections.Add(3, "Dinner");

            Actions = new Dictionary<string, string>();
            Actions.Add("Ok", "ok");
            Actions.Add("Cancel", "cancel");
        }

        public Toast(string title, string content, string image, string imgAlt, Dictionary<int, string> selections, Dictionary<string, string> actions)
        {
            Title = title;
            Content = content;
            Image = image;
            ImgAlt = imgAlt;
            Selections = selections;
            Actions = actions;
        }

        public string getFormatedSelections()
        {
            string selections = "";
            foreach (KeyValuePair<int,string> s in Selections)
            {
                selections += string.Format("<selection id='{0}' content='{1}' />", s.Key, s.Value);
            }
            return selections;
        }

        public string getFormatedActions()
        {
            string actions = "";
            foreach (KeyValuePair<string, string> a in Actions)
            {
                actions += string.Format("<action content='{0}' arguments='{1}' />", a.Key, a.Value);
            }
            return actions;
        }
    }
}

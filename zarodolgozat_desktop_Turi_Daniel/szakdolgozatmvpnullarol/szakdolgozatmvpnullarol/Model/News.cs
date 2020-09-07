using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szakdolgozatmvpnullarol.Model
{
    public class News
    {
        private string title; private string text; private string pic;
        public string getTitle { get => title; }
        public string getText { get => text; }
        public string getPic { get => pic; }
        public News(string title, string text, string pic)
        {
            this.title = title; this.text = text; this.pic = pic;
        }
    }
}

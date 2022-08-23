using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class ImagePost : Post
    {
        protected string ImageURL { get; set; }


        public ImagePost() 
        { 
            
        }

        public ImagePost(string title, string sendByUserName, string imageURL, bool isPublic = true)
        {
            // base properties
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUserName = sendByUserName;
            this.IsPublic = isPublic;

            // image post properties
            this.ImageURL = imageURL;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - by {3}", this.ID, this.Title, this.ImageURL, this.SendByUserName);
        }
    }
}

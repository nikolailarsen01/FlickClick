using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class NewsAndUpcomingModel
    {
        public List<NewsModel> News { get; set; }
        public List<PreviewMovieModel> ComingSoon { get; set; }
    }
}

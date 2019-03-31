using System;
using System.Collections.Generic;

namespace TheMovieDb
{
    public class MovieWrapper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public bool Adult { get; set; }
        public bool Video { get; set; }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public double Pupularity { get; set; }
        public IEnumerable<GenreWrapper> Genres { get; set; }

        public string Poster { get => $"{ConstantsHelper.ImageUrl}{PosterPath}"; }
        public string Backdrop { get => $"{ConstantsHelper.ImageUrl}{BackdropPath}"; }
        public string Date { get => DateTimeOffset.Parse(ReleaseDate).ToString("dd/MM/yyyy"); }
    }
}

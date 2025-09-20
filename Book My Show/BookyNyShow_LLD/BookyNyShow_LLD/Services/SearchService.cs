using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Services;

public class SearchService
{
    private readonly List<Movie> _movies;
    private readonly List<Theatre> _theatres;
    
    public SearchService(List<Movie> movies, List<Theatre> theatres)
    {
        _movies = movies;
        _theatres = theatres;
    }

    public List<Movie> SearchMovies(string city, string title = "")
    {
        var result = new List<Movie>();

        foreach (var movie in _movies)
        {
            if (string.IsNullOrEmpty(title) ||
                movie.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                result.Add(movie);
            }
        }

        return result;
    }

    public List<Show> GetShows(string city, Movie movie)
    {
        var result = new List<Show>();

        foreach (var theatre in _theatres)
        {
            if (!theatre.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                continue;
            {
                foreach (var auditorium in theatre.Auditoriums)
                {
                    foreach (var show in auditorium.Shows)
                    {
                        if (show.Movie.Id == movie.Id)
                        {
                            result.Add(show);
                        }
                    }
                }
            }
        }

        return result;
    }
}
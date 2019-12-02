using System;
using System.Text;
using VinylRecordSale.Domain.Enums;

namespace VinylRecordSale.Domain.Commons
{
    public static class Extensions
    {
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public static string ToText(this object value)
        {
            return string.IsNullOrEmpty(value?.ToString())
                ? string.Empty
                : value.ToString();
        }

        public static string GetNameMusicGenre(this MusicGenreEnum genreEnum)
        {
            string genre;

            switch (genreEnum)
            {
                case MusicGenreEnum.Pop:
                    genre = "pop";
                    break;
                case MusicGenreEnum.Mpb:
                    genre = "mpb";
                    break;
                case MusicGenreEnum.Classic:
                    genre = "classical";
                    break;
                case MusicGenreEnum.Rock:
                    genre = "rock";
                    break;
                default:
                    genre = string.Empty;
                    break;
            }

            return genre;
        }
    }
}
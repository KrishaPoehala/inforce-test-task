using Shorify.Application.Common.Interfaces;
using System.Text;

namespace Shortify.Infrastucture.Services;

public class UrlShortener : IUrlShortener
{
    private const string Alphabet = "FjTG0s5dgWkbLf_8etOZqMzNhmp7u6lUJoXIDiQB9-wRxCKyrPcv4En3Y21aASHV";
    private static readonly long Base = Alphabet.Length;
    public string GenerateShortenedUrl(long uniqueId)
    {
        var sb = new StringBuilder();
        do
        {
            sb.Append(Alphabet[(int)(uniqueId % Base)]);
            uniqueId /= Base;
        } while (uniqueId > 0);

        return sb.ToString();
    }
}

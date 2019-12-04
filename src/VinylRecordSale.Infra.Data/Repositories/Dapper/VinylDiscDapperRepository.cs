using Dapper;
using System.Collections.Generic;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.Dapper.Commons;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper
{
    public class VinylDiscDapperRepository : DapperRepositoryBase<VinylDisc>, IVinylDiscDapperRepository
    {
        private readonly IContextDapper _context;

        public VinylDiscDapperRepository(IContextDapper context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<VinylDisc> Get(int page, int musicGenreId)
        {
            return _context.Connection.Query<VinylDisc, MusicGenre, VinylDisc>(
                @"SELECT *
                  FROM VinylRecordSale.VinylDiscs v
                  INNER JOIN VinylRecordSale.MusicGenres m ON v.MusicGenreId = m.MusicGenreId
                  WHERE v.MusicGenreId = @genreId
                  ORDER BY v.Name ASC
                  OFFSET @skip ROWS
                  FETCH NEXT @take ROWS ONLY;",
                map: (vinylMusic, musicGenre) =>
                {
                    vinylMusic.SetMusicGenre(musicGenre);
                    return vinylMusic;
                },
                splitOn: "MusicGenreId, MusicGenreId",
                param: new { genreId = musicGenreId, skip = Util.GetSkip(page), take = Util.Take });
        }
    }
}
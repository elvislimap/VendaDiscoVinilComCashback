namespace VinylRecordSale.Infra.Data.Repositories.Commons
{
    public class Util
    {
        public const int Take = 10;

        public static int GetSkip(int page)
        {
            page = page == 0 ? 1 : page;
            return page * Take - Take;
        }
    }
}
using JogoJusto.Models;

namespace JogoJusto.AppDta.Repository
{
    public class MeyaEsgRepository : IMetaEsgRepository
    {
        private readonly JogoJustoDbContext _jogodbcontext;

        public MeyaEsgRepository(JogoJustoDbContext jogodbcontext)
        {
            _jogodbcontext = jogodbcontext;
        }

        public void AtualizarMetaEsg(MetaEsgModel meta)
        {
            _jogodbcontext.MetaEsg.Update(meta);
            _jogodbcontext.SaveChanges();
        }

        public void CriarMetaEsg(MetaEsgModel meta)
        {
            _jogodbcontext.MetaEsg.Add(meta);
            _jogodbcontext.SaveChanges();
        }

        public void DeletarMetaEsg(int id)
        {
            _jogodbcontext.MetaEsg.Remove(new MetaEsgModel { IdMetaEsg = id });
        }

        public MetaEsgModel? ObterMetaEsgPorId(int id)
        {
            _jogodbcontext.MetaEsg.Find(id);
            return null;
        }

        public IEnumerable<MetaEsgModel> ObterTodasMetasEsg()
        {
            _jogodbcontext.MetaEsg.ToList();
            return Enumerable.Empty<MetaEsgModel>();
        }
    }
}

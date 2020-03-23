using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetModule5TP2.Models.DAL
{
    public class SamouraiDal : IDal<Samourai>
    {

        private Context bdd;
        public SamouraiDal()
        {
            bdd = new Context();
        }

        public Samourai create(Samourai t)
        {
            Samourai sam = bdd.Samourais.Add(t);
            bdd.SaveChanges();
            return sam;
        }

        public bool delete(int id)
        {
            Samourai sam = getOne(id);
            if(sam != null)
            {
                bdd.Samourais.Remove(sam);
                bdd.SaveChanges();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Samourai> getAll()
        {
            return bdd.Samourais.ToList();
        }

        public Samourai getOne(int id)
        {
            return bdd.Samourais.Find(id);
        }

        public Samourai update(Samourai t)
        {
            Samourai sam = getOne(t.Id);
            if(sam != null)
            {
                sam.Arme = t.Arme;
                sam.Force = t.Force;
                sam.Nom = t.Nom;
               // bdd.Entry(sam).CurrentValues.SetValues(t);
                bdd.SaveChanges();
                return sam;
            }
            return null;
        }
    }
}
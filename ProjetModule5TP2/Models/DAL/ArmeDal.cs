using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetModule5TP2.Models.DAL
{
    public class ArmeDal : IDal<Arme>
    { 

        private Context bdd;
        public ArmeDal()
        {
            bdd = new Context();
        }

        public Arme create(Arme t)
        {
            Arme arme = bdd.Armes.Add(t);
            bdd.SaveChanges();
            return arme;
        }

        public bool delete(int id)
        {
            Arme arme = getOne(id);
            if(arme != null)
            {
                bdd.Armes.Remove(arme);
                bdd.SaveChanges();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Arme> getAll()
        {
            return bdd.Armes.ToList();
        }

        public Arme getOne(int id)
        {
            return bdd.Armes.Find(id);
        }

        public Arme update(Arme t)
        {
            Arme arme = getOne(t.Id); 
            if(arme != null)
            {
                bdd.Entry(arme).CurrentValues.SetValues(t);
                bdd.SaveChanges();
                return arme;
            }
            return null;
        }
    }
}
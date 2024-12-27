using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class SVDAL
    {
        private StudentDBContext context;

        public SVDAL()
        {
            context = new StudentDBContext();
        }

        public List<Sinhvien> GetAll()
        {
            return context.Sinhviens.Include(s  => s.Lop).ToList();
        }

        public void Add(Sinhvien sv)
        {
            context.Sinhviens.Add(sv);
            context.SaveChanges();
        }

        public void Update (Sinhvien sv)
        {
            context.Entry(sv).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Sinhvien sv)
        {
            context.Sinhviens.Remove(sv);
            context.SaveChanges();
        }

        public List<Lop> GetAllClasses()
        {
            return context.Lops.ToList();
        }

        public List<Sinhvien> FindByName (string name)
        {
            return context.Sinhviens.Include(s => s.Lop)
                .Where(s => s.HotenSV.Contains(name)).ToList();
        }
    }
}

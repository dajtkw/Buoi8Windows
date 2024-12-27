using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class SVBUS
    {
        private SVDAL svdal;

        public SVBUS ()
        {
            svdal = new SVDAL ();
        }

        public List<Sinhvien> GetALLStudent()
        {
            return svdal.GetAll();
        }

        public void AddSinhVien(Sinhvien sv)
        {
             svdal.Add(sv);
        } 

        public void UpdateSinhVien(Sinhvien sv)
        {
            svdal.Update(sv);
        }

        public void DeleteSinhVien(Sinhvien sv)
        {
            svdal.Delete(sv);
        }

        public List<Lop> GetAllClasses ()
        {
            return svdal.GetAllClasses();
        }

        public List<Sinhvien> FindByName(string name)
        {
            return svdal.FindByName(name);
        }
    }
}

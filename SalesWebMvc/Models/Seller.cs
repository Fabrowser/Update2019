using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace SalesWebMvc.Models
{
    public class Seller
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="{0} requerido")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} tamanho deve ser entre {2} e {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Entre com um e-mail válido")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} requerido")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} requerido")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double  BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
            {

            }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSalles(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double totalSales(DateTime initial, DateTime final)
        {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}

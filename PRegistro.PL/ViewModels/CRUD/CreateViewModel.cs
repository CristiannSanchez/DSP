using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using PStudent.BL;
using PStudent.BL.PagModelo;

namespace PRegistro.PL.ViewModels.CRUD
{
    public class CreateViewModel : PRegistro.PL.ViewModels.MasterPageViewModel
    {
        private readonly StudentService studentService;

        public DetalleDeContacto Student { get; set; } = new DetalleDeContacto { FehcaDeNacimiento = DateTime.UtcNow.Date };
        public CreateViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public async Task addContacto()
        {
            await studentService.InsertStudentAsync(Student);
            Context.RedirectToRoute("Default");
        }
    }
}


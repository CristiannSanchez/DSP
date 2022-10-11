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
    public class DetallesViewModel : PRegistro.PL.ViewModels.MasterPageViewModel
    {
        private readonly StudentService studentService;

        public DetallesViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public DetalleDeContacto Student { get; set; }

        public override async Task PreRender()
        {
            int id = Convert.ToInt32(Context.Parameters["Id"]);
            Student = await studentService.GetStudentByIdAsync(id);
            await base.PreRender();
        }
        
        public async Task DeleteContacto()
        {
            await studentService.DeleteContactoAsync(Student.Id);
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
        }
    }
}


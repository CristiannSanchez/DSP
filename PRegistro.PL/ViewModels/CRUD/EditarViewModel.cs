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
    public class EditarViewModel : PRegistro.PL.ViewModels.MasterPageViewModel
    {
        private readonly StudentService studentService;

        public DetalleDeContacto Student { get; set; }

        public EditarViewModel(StudentService studentService)        {
            this.studentService = studentService;
        }

        public override async Task PreRender()
        {
            int id=0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                Student = await studentService.GetStudentByIdAsync(id);
            }
            await base.PreRender();
        }

        public async Task EditarContacto()
        {
            await studentService.UpdateStudentAsync(Student);
            Context.RedirectToRoute("CRUD_Detalles", new {id = Student.Id});
        }
    }
}


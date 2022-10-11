using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using PStudent.BL;
using PStudent.BL.PagModelo;

namespace PRegistro.PL.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

		private readonly StudentService studentService;

		public DefaultViewModel(StudentService studentService)
		{
			this.studentService = studentService;
		}

		public List<RegistroDeContactos> Students { get; set; }

		public override async Task PreRender()
		{
			Students = await studentService.GetAllStudentAsync();
			await base.PreRender();
		}

    }
}
